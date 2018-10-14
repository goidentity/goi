using GoIdentity.Utilities.Constants;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Linq;

namespace GoIdentity.Utilities.Extensions
{
    public static class ExcelHelper
    {
        private static string GetFormattedValue(ICell cell, DataFormatter dataFormatter, IFormulaEvaluator formulaEvaluator)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                try
                {
                    // Get evaluated and formatted cell value
                    returnValue = dataFormatter.FormatCellValue(cell, formulaEvaluator);
                }
                catch
                {
                    // When failed in evaluating the formula, use stored values instead...
                    // and set cell value for reference from formulae in other cells...
                    if (cell.CellType == CellType.Formula)
                    {
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                cell.SetCellValue(cell.StringCellValue);
                                break;
                            case CellType.Numeric:
                                returnValue = dataFormatter.FormatRawCellContents(cell.NumericCellValue, 0, cell.CellStyle.GetDataFormatString());
                                cell.SetCellValue(cell.NumericCellValue);
                                break;
                            case CellType.Boolean:
                                returnValue = cell.BooleanCellValue.ToString();
                                cell.SetCellValue(cell.BooleanCellValue);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        returnValue = cell.ToString();
                    }
                }
            }

            return (returnValue ?? string.Empty).Trim();
        }

        public static DataSet ReadExcel(string filePath, int rowPosition = 0, bool singleSheet = false)
        {
            DataFormatter dataFormatter;
            IFormulaEvaluator formulaEvaluator;
            IWorkbook workbook;

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(stream);

                dataFormatter = new DataFormatter(CultureInfo.InvariantCulture);
                formulaEvaluator = WorkbookFactory.CreateFormulaEvaluator(workbook);
            }
            var dataSet = new DataSet();
            for (int r = 0; r < (singleSheet ? 1 : workbook.NumberOfSheets); r++)
            {
                ISheet sheet = workbook.GetSheetAt(r); // zero-based index of your target sheet
                DataTable dt = new DataTable(sheet.SheetName);

                // write header row
                IRow headerRow = sheet.GetRow(rowPosition);
                foreach (ICell headerCell in headerRow)
                {
                    dt.Columns.Add(headerCell.ToString());
                }

                // write the rest
                int rowIndex = 0;
                foreach (IRow row in sheet)
                {
                    // skip header row
                    if (rowIndex++ <= rowPosition) continue;
                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (row.Cells.Count > i)
                        {
                            dataRow[i] = GetFormattedValue(row.Cells[i], dataFormatter, formulaEvaluator);
                            //dataRow[i] = row.Cells[i].ToString();
                        }
                        else
                        {
                            dataRow[i] = DBNull.Value;
                        }
                    }
                    dt.Rows.Add(dataRow);
                    dt.AcceptChanges();
                }
                dataSet.Tables.Add(dt);
            }
            return dataSet;
        }

        public static DataTable ToDataTable<T>(this List<T> items)
            where T : class, new()
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            IDictionary<Type, ICollection<PropertyInfo>> _Properties = new Dictionary<Type, ICollection<PropertyInfo>>();

            try
            {                
                var tableColumns = new List<string>();
                foreach (DataColumn item in table.Columns)
                {
                    tableColumns.Add(item.ColumnName);
                }

                var objType = typeof(T);
                ICollection<PropertyInfo> properties;

                lock (_Properties)
                {
                    if (!_Properties.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite).ToList();
                        _Properties.Add(objType, properties);
                    }
                }

                var list = new List<T>(table.Rows.Count);

                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        if (!tableColumns.Contains(prop.Name)) continue;

                        try
                        {
                            var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                            var safeValue = row[prop.Name] == DBNull.Value ? null : Convert.ChangeType(row[prop.Name], propType);

                            prop.SetValue(obj, safeValue, null);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return new List<T>();
            }
        }

        public static void CreateExcel(this DataTable dataTable, int organizationId, string fileName, bool hideFirstRow = false)
        {
            var wb = new XSSFWorkbook();
            var sheet = wb.CreateSheet();

            var headerRow = sheet.CreateRow(0); //To add a row in the table
            foreach (DataColumn column in dataTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);

            int rowIndex = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dataTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }

            if (!Directory.Exists(ConnectionStrings.DOCS_PATH + @"\" + organizationId))
            {
                Directory.CreateDirectory(ConnectionStrings.DOCS_PATH + @"\" + organizationId);
            }

            var path = Path.Combine(ConnectionStrings.DOCS_PATH + @"\" + organizationId, fileName);

            using (var sw = new FileStream(path, FileMode.Create))
            {
                wb.Write(sw);
            }
        }
    }
}
