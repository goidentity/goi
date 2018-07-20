using System.Data;

namespace GoIdentity.ResourceAccess
{
    public static class UserDefinedTableTypes
    {
        #region Domain
        public static DataTable NavigationItemType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("NavigationUid", DbColumnType.UniqueIdentifier)
                    .AddColumn("NavigationId", DbColumnType.Int)

                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("ReportDocumentId", DbColumnType.Int)
                    .AddColumn("DashboardId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)

                    .AddColumn("NavigationPath", DbColumnType.String)
                    .AddColumn("DependentOn", DbColumnType.String)
                    .AddColumn("RedirectPath", DbColumnType.String)

                    .AddColumn("LevelId", DbColumnType.Byte)
                    .AddColumn("ParentUid", DbColumnType.UniqueIdentifier)
                    .AddColumn("ParentNavigationId", DbColumnType.Int)

                    .AddColumn("ImagePath", DbColumnType.String)
                    .AddColumn("SortId", DbColumnType.Int)

                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("IsActive", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable LookupType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LookupId", DbColumnType.Int)
                    .AddColumn("OrganizationId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("SortType", DbColumnType.Byte)
                    .AddColumn("Category", DbColumnType.String)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable LookupDetailType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LookupDetailId", DbColumnType.Int)
                    .AddColumn("LookupId", DbColumnType.Int)
                    .AddColumn("Value", DbColumnType.String)
                    .AddColumn("SequenceId", DbColumnType.Short)
                    .AddColumn("SortId", DbColumnType.Short)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable AccessControlType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("AccessControlId", DbColumnType.Int)
                    .AddColumn("NavigationUid", DbColumnType.UniqueIdentifier)
                    .AddColumn("RoleId", DbColumnType.Int)
                    .AddColumn("IsView", DbColumnType.Bool)
                    .AddColumn("IsInsert", DbColumnType.Bool)
                    .AddColumn("IsEdit", DbColumnType.Bool)
                    .AddColumn("IsDelete", DbColumnType.Bool)
                    .AddColumn("IsPrint", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region Currency
        public static DataTable CurrencyType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("CurrencyId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("Symbol", DbColumnType.String)
                     .AddColumn("Change", DbColumnType.String)
                    .AddColumn("IsPrimary", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Exchange
        public static DataTable ExchangeType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ExchangeRateId", DbColumnType.Int)
                     .AddColumn("CurrencyId", DbColumnType.Int)
                    .AddColumn("ExchangeDate", DbColumnType.DateTime)
                     .AddColumn("Amount", DbColumnType.Decimal)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Accounting
        public static DataTable AccountHead
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("IsGroup", DbColumnType.Bool)
                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("AccountTypeId", DbColumnType.Byte)
                    .AddColumn("ParentId", DbColumnType.Int)
                    .AddColumn("Description", DbColumnType.String)
                    .AddColumn("CurrencyId", DbColumnType.Int)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region AccountHeadDetails
        public static DataTable AccountHeadDetails
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("DebitAmount", DbColumnType.Decimal)
                    .AddColumn("CreditAmount", DbColumnType.Decimal)
                    .AddColumn("OpeningDr", DbColumnType.Decimal)
                    .AddColumn("OpeningCr", DbColumnType.Decimal)
                    .AddColumn("ClosingDr", DbColumnType.Decimal)
                    .AddColumn("ClosingCr", DbColumnType.Decimal);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Voucher
        public static DataTable VoucherType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("VoucherTypeId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("ParentId", DbColumnType.Short)
                    .AddColumn("DefaultAccountHeadId", DbColumnType.Int)
                    .AddColumn("AccTypeIds", DbColumnType.String)
                    .AddColumn("DefaultDetailAccountHeadId", DbColumnType.Int)
                    .AddColumn("DetailAccTypeIds", DbColumnType.String)
                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("IsActive", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable Voucher
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("VoucherId", DbColumnType.Int)
                    .AddColumn("VoucherTypeId", DbColumnType.Short)
                    .AddColumn("VoucherSubTypeId", DbColumnType.Short)
                    .AddColumn("VoucherNumber", DbColumnType.String)
                    .AddColumn("VoucherDate", DbColumnType.DateTime)

                    .AddColumn("ChequeNumber", DbColumnType.String)
                    .AddColumn("Narration", DbColumnType.String)

                    .AddColumn("ChequeStatusLookupId", DbColumnType.Int)
                    .AddColumn("ClearanceDate", DbColumnType.DateTime)
                    .AddColumn("ConvertedVoucherId", DbColumnType.Int)

                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("RefTransactionId", DbColumnType.Int)
                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable VoucherItem
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("VoucherItemId", DbColumnType.Int)
                    .AddColumn("VoucherId", DbColumnType.Int)
                    .AddColumn("ByTo", DbColumnType.String)
                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("DebitAmount", DbColumnType.Decimal)
                    .AddColumn("CreditAmount", DbColumnType.Decimal)
                    .AddColumn("ExchangeDebitAmount", DbColumnType.Decimal)
                    .AddColumn("ExchangeCreditAmount", DbColumnType.Decimal)
                    .AddColumn("IsPrimary", DbColumnType.Byte)
                    .AddColumn("LineNarration", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable ArApItem
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ArApId", DbColumnType.Int)
                    .AddColumn("TransactionType", DbColumnType.String)

                    .AddColumn("DocNo", DbColumnType.String)
                    .AddColumn("DocDate", DbColumnType.DateTime)
                    .AddColumn("DueDate", DbColumnType.DateTime)

                    .AddColumn("DataSetOrVoucherTypeId", DbColumnType.Int)
                    .AddColumn("SourceId", DbColumnType.Int)

                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("CustomerId", DbColumnType.Int)

                    .AddColumn("Amount", DbColumnType.Decimal)
                    .AddColumn("CurrencyId", DbColumnType.Int)
                    .AddColumn("ExchangeRate", DbColumnType.Decimal)
                    .AddColumn("ExchangeAmount", DbColumnType.Decimal)

                    .AddColumn("ReferenceId", DbColumnType.Int)
                    .AddColumn("R_P", DbColumnType.String)
                    .AddColumn("OnAccountAmount", DbColumnType.Decimal)
                    .AddColumn("ExchangeOnAccountAmount", DbColumnType.Decimal)

                     .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region TransactionBuilder
        public static DataTable PageDocument
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("PageDocumentId", DbColumnType.Int)
                    .AddColumn("DocumentTitle", DbColumnType.String)
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("DetailedDataSetId", DbColumnType.Int)
                    .AddColumn("Detailed_ExtDataSetId", DbColumnType.Int)

                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable DataSetData
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("Id", DbColumnType.Long)
                    .AddColumn("KeyId", DbColumnType.Long)
                    .AddColumn("UniqueId", DbColumnType.UniqueIdentifier)
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("ParentKeyId", DbColumnType.Long)

                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("ApprovalStatusId", DbColumnType.Long)
                    .AddColumn("ApprovalText", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable DataSet
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("Name", DbColumnType.String)
                    .AddColumn("DisplayTitle", DbColumnType.String)
                    .AddColumn("ParentDataSetId", DbColumnType.Int)

                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("DataSetTypeLookupId", DbColumnType.Int)

                    .AddColumn("Category", DbColumnType.String)
                    .AddColumn("DependentOn", DbColumnType.String)
                    .AddColumn("RedirectPath", DbColumnType.String)

                    .AddColumn("PageBannerId", DbColumnType.Int)
                    .AddColumn("BannerParm", DbColumnType.String)

                    .AddColumn("DataBannerId", DbColumnType.Int)
                    .AddColumn("DataBannerParm", DbColumnType.String)

                    .AddColumn("FallbackPageBannerId", DbColumnType.Int)
                    .AddColumn("FallbackBannerParm", DbColumnType.String)

                    .AddColumn("PostAction", DbColumnType.String)

                    .AddColumn("DocumentLayoutLookupId", DbColumnType.Int)
                    .AddColumn("ChildDataSetIds", DbColumnType.String)

                    .AddColumn("InventoryUpdateLookupId", DbColumnType.Int)
                    .AddColumn("ArApUpdateLookupId", DbColumnType.Int)

                    .AddColumn("IsActive", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable DataSetDetail
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("DataSetDetailId", DbColumnType.Int)
                    .AddColumn("DataSetId", DbColumnType.Int)

                    .AddColumn("FieldName", DbColumnType.String)
                    .AddColumn("IsFixed", DbColumnType.Bool)
                    .AddColumn("InputDataTypeId", DbColumnType.Byte)

                    .AddColumn("DisplayTitle", DbColumnType.String)
                    .AddColumn("InputControlTypeId", DbColumnType.Byte)

                    .AddColumn("SourceTypeId", DbColumnType.Byte)
                    .AddColumn("Source", DbColumnType.String)
                    .AddColumn("DisplayField", DbColumnType.String)
                    .AddColumn("ValueField", DbColumnType.String)
                    .AddColumn("Parms", DbColumnType.String)
                    .AddColumn("Mask", DbColumnType.String)
                    .AddColumn("OtherOptions", DbColumnType.String)

                    .AddColumn("DefaultValue", DbColumnType.String)

                    .AddColumn("Formula", DbColumnType.String)

                    .AddColumn("Scope", DbColumnType.String)
                    .AddColumn("Required", DbColumnType.Bool)
                    .AddColumn("IsTotalRequired", DbColumnType.Bool)
                    .AddColumn("IsParentMappField", DbColumnType.Bool)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("HideWhenNoData", DbColumnType.Bool)
                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("IncludeDefaultValue", DbColumnType.Bool)

                    .AddColumn("DisabledWhen", DbColumnType.String)

                    .AddColumn("TriggerToLoadDetail", DbColumnType.Bool)
                    .AddColumn("SplitAmount", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable ReportDocumentType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ReportDocumentId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("IsWidget", DbColumnType.Bool)
                    .AddColumn("ReportTypeLookupId", DbColumnType.Int)
                    .AddColumn("ReportLayoutLookupId", DbColumnType.Int)

                    .AddColumn("Category", DbColumnType.String)
                    .AddColumn("ReportParmDatasetName", DbColumnType.String)
                    .AddColumn("SubReportDocumentId", DbColumnType.Int)

                    .AddColumn("Conditions", DbColumnType.String)
                    .AddColumn("DirectQuery", DbColumnType.String)
                    .AddColumn("DirectQueryOrderBy", DbColumnType.String)
                    .AddColumn("SqlQuery", DbColumnType.String)

                    .AddColumn("PivotRows", DbColumnType.String)
                    .AddColumn("PivotColumns", DbColumnType.String)
                    .AddColumn("PivotValues", DbColumnType.String)
                    .AddColumn("GroupByColumns", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable ReportTableMappingType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ReportTableMappingId", DbColumnType.Int)
                    .AddColumn("ReportDocumentId", DbColumnType.Int)
                    .AddColumn("ReportJoinTypeLookupId", DbColumnType.Int)
                    .AddColumn("ObjectName", DbColumnType.String)
                    .AddColumn("Alias", DbColumnType.String)
                    .AddColumn("SortId", DbColumnType.Short)
                    .AddColumn("Condition", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable ReportColType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ReportColId", DbColumnType.Int)
                    .AddColumn("ReportDocumentId", DbColumnType.Int)

                    .AddColumn("ObjectName", DbColumnType.String)
                    .AddColumn("ColName", DbColumnType.String)
                    .AddColumn("DisplayName", DbColumnType.String)
                    .AddColumn("AggregateFunctionLookupId", DbColumnType.Int)
                    .AddColumn("ColumnDataTypeLookupId", DbColumnType.Int)

                    .AddColumn("IsGroup", DbColumnType.Bool)
                    .AddColumn("GrandTotal", DbColumnType.Bool)
                    .AddColumn("SubTotal", DbColumnType.Bool)
                    .AddColumn("SortId", DbColumnType.Short)

                    .AddColumn("MinWidth", DbColumnType.Short)
                    .AddColumn("MaxWidth", DbColumnType.Short)

                    .AddColumn("IsHidden", DbColumnType.Bool)
                    .AddColumn("DisplayFormat", DbColumnType.String)
                    .AddColumn("TextAlignLookupId", DbColumnType.Int)

                    .AddColumn("GroupName", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable StockUpdateType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("StockUpdateId", DbColumnType.Long)
                    .AddColumn("DocNo", DbColumnType.String)
                    .AddColumn("DocDate", DbColumnType.DateTime)
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("DataSetKeyId", DbColumnType.Long)
                    .AddColumn("DataSetDetailId", DbColumnType.Long)
                    .AddColumn("OtherReferenceId", DbColumnType.String)

                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("ProductId", DbColumnType.Long)
                    .AddColumn("Quantity", DbColumnType.Decimal)
                    .AddColumn("Rate", DbColumnType.Decimal)

                    .AddColumn("LocationId", DbColumnType.Long)
                    .AddColumn("BatchNo", DbColumnType.String)
                    .AddColumn("MfgDate", DbColumnType.DateTime)
                    .AddColumn("ExpiryDate", DbColumnType.DateTime)

                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable LinkDataType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LinkDataId", DbColumnType.Int)
                    .AddColumn("DocNo", DbColumnType.String)
                    .AddColumn("DocDate", DbColumnType.DateTime)
                    .AddColumn("DueDate", DbColumnType.DateTime)

                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("DataSetKeyId", DbColumnType.Long)
                    .AddColumn("DataSetDetailUniqueId", DbColumnType.UniqueIdentifier)

                    .AddColumn("LinkId", DbColumnType.Int)
                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("CustomerId", DbColumnType.Int)
                    .AddColumn("ProductId", DbColumnType.Int)

                    .AddColumn("Quantity", DbColumnType.Decimal)
                    .AddColumn("Rate", DbColumnType.Decimal)
                    .AddColumn("Amount", DbColumnType.Decimal)

                    .AddColumn("LocationId", DbColumnType.Int)
                    .AddColumn("BatchNo", DbColumnType.String)
                    .AddColumn("MfgDate", DbColumnType.DateTime)
                    .AddColumn("ExpiryDate", DbColumnType.DateTime)

                    .AddColumn("ReferenceId", DbColumnType.Int)
                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable DashboardHeaderType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("DashboardHeaderId", DbColumnType.Int)
                    .AddColumn("DisplayTitle", DbColumnType.String)
                    .AddColumn("DashboardParmDatasetName", DbColumnType.String)
                    .AddColumn("JsonFeed", DbColumnType.String)
                    .AddColumn("IsActive", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable DashboardDetailType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("DashboardDetailId", DbColumnType.Int)
                    .AddColumn("DashboardHeaderId", DbColumnType.Int)
                    .AddColumn("ReportDocumentId", DbColumnType.Int);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable PrintDocument
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("PrintDocumentId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("PrintSourceLookupTypeId", DbColumnType.Int)
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("VoucherTypeId", DbColumnType.Int)

                    .AddColumn("OtherSource", DbColumnType.String)
                    .AddColumn("PrintTypeLookupId", DbColumnType.Int)
                    .AddColumn("PrintPageSizeLookupId", DbColumnType.Int)
                    .AddColumn("Height", DbColumnType.Int)
                    .AddColumn("Width", DbColumnType.Int)

                    .AddColumn("IsDefault", DbColumnType.Bool)
                    .AddColumn("JsonFeed", DbColumnType.String)
                    .AddColumn("FontFamily", DbColumnType.String)
                    .AddColumn("FontSize", DbColumnType.Decimal)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable PrintTableMapping
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("PrintTableMappingId", DbColumnType.Int)
                    .AddColumn("PrintDocumentId", DbColumnType.Int)
                    .AddColumn("ObjectName", DbColumnType.String)
                    .AddColumn("Alias", DbColumnType.String)
                    .AddColumn("Condition", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable LinkSetup
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LinkSetupId", DbColumnType.Int)
                    .AddColumn("LinkTitle", DbColumnType.String)

                    .AddColumn("BaseDataSetId", DbColumnType.Int)
                    .AddColumn("LinkDataSetId", DbColumnType.Int)
                    .AddColumn("BaseField", DbColumnType.String)
                    .AddColumn("KeyField", DbColumnType.String)

                    .AddColumn("IsEditBase", DbColumnType.Bool)
                    .AddColumn("IsExceedBase", DbColumnType.Bool)
                    .AddColumn("IsMandotry", DbColumnType.Bool)
                    .AddColumn("IsLinkFifo", DbColumnType.Bool)
                    .AddColumn("IsLinkUpdate", DbColumnType.Bool)

                    .AddColumn("ParmDataSetId", DbColumnType.Int)
                    .AddColumn("Query", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable LinkData
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LinkDataId", DbColumnType.Int)
                    .AddColumn("DocNo", DbColumnType.String)

                    .AddColumn("DocDate", DbColumnType.DateTime)
                    .AddColumn("DueDate", DbColumnType.DateTime)

                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("DataSetKeyId", DbColumnType.Int)
                    .AddColumn("DataSetDetailUniqueId", DbColumnType.UniqueIdentifier)

                    .AddColumn("LinkId", DbColumnType.Int)
                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("CustomerId", DbColumnType.Int)
                    .AddColumn("ProductId", DbColumnType.Int)

                    .AddColumn("Quantity", DbColumnType.Decimal)
                    .AddColumn("Rate", DbColumnType.Decimal)
                    .AddColumn("Amount", DbColumnType.Decimal)

                    .AddColumn("LocationId", DbColumnType.Int)
                    .AddColumn("BatchNo", DbColumnType.String)
                    .AddColumn("MfgDate", DbColumnType.DateTime)
                    .AddColumn("ExpiryDate", DbColumnType.DateTime)
                    .AddColumn("ReferenceId", DbColumnType.Int)
                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Product
        public static DataTable Product
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ProductId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("IsGroup", DbColumnType.Bool)
                    .AddColumn("Description", DbColumnType.String)
                    .AddColumn("JsonFeed", DbColumnType.String)
                    .AddColumn("ParentId", DbColumnType.Int)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);



                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Role
        public static DataTable Role
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("RoleId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("DeafultPage", DbColumnType.Int)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("IsAdmin", DbColumnType.Bool)
                    .AddColumn("IsDefault", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Serial Number
        public static DataTable SerialNumber
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SerialNumberId", DbColumnType.Int)
                    .AddColumn("VoucherTypeId", DbColumnType.Byte)
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("OtherSource", DbColumnType.String)
                    .AddColumn("FieldName", DbColumnType.String)
                    .AddColumn("Prefix", DbColumnType.String)
                    .AddColumn("Suffix", DbColumnType.String)
                    .AddColumn("PadLeftSize", DbColumnType.String)
                    .AddColumn("TrackNumber", DbColumnType.Int)
                    .AddColumn("IgnorePrefixSuffix", DbColumnType.Bool)
                    .AddColumn("IsActive", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable SerialNumberTracker
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SerialNumberTrackerId", DbColumnType.Int)
                    .AddColumn("SerialNumberId", DbColumnType.Int)
                    .AddColumn("Prefix", DbColumnType.String)
                    .AddColumn("Suffix", DbColumnType.String)
                    .AddColumn("TrackNumber", DbColumnType.Int)
                    .AddColumn("IsActive", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Budget
        public static DataTable Budget
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("BudgetId", DbColumnType.Int)
                    .AddColumn("AccountHeadId", DbColumnType.String)
                    .AddColumn("MonthYear", DbColumnType.DateTime)
                     .AddColumn("Amount", DbColumnType.Decimal)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);
                foreach (var item in columnCollection) result.Columns.Add(item);
                return result;
            }
        }
        #endregion

        #region Organization
        public static DataTable MapUserOrganization
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection

                     .AddColumn("MapUserOrganizationId", DbColumnType.Int)
                     .AddColumn("UserId", DbColumnType.Int)
                     .AddColumn("OrganizationId", DbColumnType.Int)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable ClientType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ClientId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("SiteUrl", DbColumnType.String)
                    .AddColumn("IsLocked", DbColumnType.Bool)

                    .AddColumn("ProductLogo", DbColumnType.String)
                    .AddColumn("FooterLogo", DbColumnType.String)
                    .AddColumn("ProductName", DbColumnType.String)

                    .AddColumn("PoweredByName", DbColumnType.String)

                    .AddColumn("IsGoogleTwoFactorEnabled", DbColumnType.Bool)
                    .AddColumn("IgnoreTwoFactorRoles", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable OrganizationType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("OrganizationId", DbColumnType.Short)
                    .AddColumn("ClientId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("ShortName", DbColumnType.String)
                    .AddColumn("IsLocked", DbColumnType.Bool)
                    .AddColumn("IsPrimary", DbColumnType.Bool)
                    .AddColumn("DatabaseName", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable RoleType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection

                    .AddColumn("MapUserRoleId", DbColumnType.Int)
                    .AddColumn("UserId", DbColumnType.Int)
                    .AddColumn("RoleId", DbColumnType.Int)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);
                return result;

            }
        }
        #endregion

        #region User
        public static DataTable UserType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("UserId", DbColumnType.Int)
                    .AddColumn("ClientId", DbColumnType.Short)
                    .AddColumn("UserName", DbColumnType.String)
                     .AddColumn("FirstName", DbColumnType.String)
                    .AddColumn("LastName", DbColumnType.String)
                    .AddColumn("DoB", DbColumnType.DateTime)
                    .AddColumn("MobileNumber", DbColumnType.String)
                    .AddColumn("Password", DbColumnType.String)
                    .AddColumn("IsHash", DbColumnType.Bool)
                    .AddColumn("FailureAttempts", DbColumnType.Short)
                    .AddColumn("IsLocked", DbColumnType.Bool)
                    .AddColumn("LockedDate", DbColumnType.DateTime)
                    .AddColumn("IsSuspended", DbColumnType.Bool)
                    .AddColumn("SuspendedDate", DbColumnType.DateTime)
                     .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region Employee
        public static DataTable Employee
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("EmployeeNumber", DbColumnType.String)
                    .AddColumn("FirstName", DbColumnType.String)
                    .AddColumn("LastName", DbColumnType.String)
                    .AddColumn("Email", DbColumnType.String)
                    .AddColumn("MobileNumber", DbColumnType.String)
                    
                    .AddColumn("DoB", DbColumnType.DateTime)
                    .AddColumn("DoJ", DbColumnType.DateTime)
                    .AddColumn("GenderId", DbColumnType.Int)
                    
                    .AddColumn("UniqueId", DbColumnType.UniqueIdentifier)
                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("IsLogInEnabled", DbColumnType.Bool)
                    .AddColumn("IsVirtual", DbColumnType.Bool)
                    .AddColumn("UserName", DbColumnType.String)
                    .AddColumn("Password", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        public static DataTable EmployeePosition
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("EmployeePositionId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)

                    .AddColumn("FromDate", DbColumnType.DateTime)
                    .AddColumn("ToDate", DbColumnType.DateTime)
                    .AddColumn("LocationId", DbColumnType.Int)
                    .AddColumn("LevelId", DbColumnType.Int)
                    .AddColumn("SupervisorId", DbColumnType.Int)

                    .AddColumn("JsonFeed", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region LeaveType
        public static DataTable LeaveType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LeaveTypeId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("IsWorkingDay", DbColumnType.Bool)
                    .AddColumn("IsOccasional", DbColumnType.Bool)
                    .AddColumn("IsActive", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Apply Leave
        public static DataTable ApplyLeave
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection

                    .AddColumn("ApplyLeaveId", DbColumnType.Int)
                    .AddColumn("LeaveTypeId", DbColumnType.Short)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("FromDate", DbColumnType.DateTime)
                    .AddColumn("FromDateIsHalf", DbColumnType.Bool)
                    .AddColumn("ToDate", DbColumnType.DateTime)
                    .AddColumn("ToDateIsHalf", DbColumnType.Bool)
                    .AddColumn("LeaveApprovalStatusId", DbColumnType.Int)
                    .AddColumn("ReasonForLeave", DbColumnType.String)
                    .AddColumn("ApproverComments", DbColumnType.String)
                    .AddColumn("EmergencyContact", DbColumnType.String)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region EarnLeaveConfig 
        public static DataTable EarnLeaveConfig
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("EarnLeaveId ", DbColumnType.Int)
                    .AddColumn("ApprisalYearId ", DbColumnType.Short)
                    .AddColumn("LeaveTypeId ", DbColumnType.Short)
                    .AddColumn("EmployeeLevelId ", DbColumnType.Short)
                    .AddColumn("FrequencyLookupId ", DbColumnType.Int)
                    .AddColumn("IsCarryForward ", DbColumnType.Bool)
                    .AddColumn("MaxLimit ", DbColumnType.Decimal)
                    .AddColumn("NoOfLeaves ", DbColumnType.Decimal)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region ApprisalYear
        public static DataTable ApprisalYearType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("FromDate", DbColumnType.DateTime)
                    .AddColumn("ToDate", DbColumnType.DateTime)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Assign Salary
        public static DataTable SalaryHeader
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SalaryHeaderId", DbColumnType.Int)
                    .AddColumn("FromDate", DbColumnType.DateTime)
                    .AddColumn("ApprisalYearId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("Additions", DbColumnType.Decimal)
                    .AddColumn("Deductions", DbColumnType.Decimal)
                    .AddColumn("Net", DbColumnType.Decimal)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable SalaryDetail
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SalaryDetailId", DbColumnType.Int)
                    .AddColumn("SalaryHeaderId", DbColumnType.Int)
                    .AddColumn("SalaryComponentId", DbColumnType.Int)
                    .AddColumn("Amount", DbColumnType.Decimal)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region SalaryComponent
        public static DataTable SalaryComponentType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SalaryComponentId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("IsAddition", DbColumnType.Bool)
                     .AddColumn("IsActive", DbColumnType.Bool)
                     .AddColumn("Variable", DbColumnType.Bool)
                    .AddColumn("Formulae", DbColumnType.String)
                    .AddColumn("SortingId", DbColumnType.Int)
                    .AddColumn("FreeEntry", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region BankAccountDetails
        public static DataTable BankAccountDetailsType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("BankAccountDetailId", DbColumnType.Int)
                    .AddColumn("AccountNumber", DbColumnType.Long)
                    .AddColumn("Bank", DbColumnType.String)
                    .AddColumn("IFSC", DbColumnType.String)
                     .AddColumn("SwiftCode", DbColumnType.String)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region OffDay
        public static DataTable OffDayType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("OffDayId", DbColumnType.Int)
                    .AddColumn("EmployeeLevelId", DbColumnType.Short)
                    .AddColumn("MonthSequenceId", DbColumnType.Int)
                    .AddColumn("WeekDayLookupId", DbColumnType.Int)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region Holiday
        public static DataTable HolidayType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("HolidayId", DbColumnType.Int)
                    .AddColumn("EmployeeLevelId", DbColumnType.Short)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("FromDate", DbColumnType.DateTime)
                    .AddColumn("ToDate", DbColumnType.DateTime)
                    .AddColumn("Reason", DbColumnType.String)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region Daily Attendance
        public static DataTable DailyAttendance
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("DailyAttendanceId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("AttendanceDate", DbColumnType.DateTime)
                    .AddColumn("CountValue", DbColumnType.Decimal)
                    .AddColumn("IsFirstHalfPresent", DbColumnType.Bool)
                    .AddColumn("IsSecondHalfPresent", DbColumnType.Bool)
                    .AddColumn("AttendanceSourceLookupId", DbColumnType.Int)
                    .AddColumn("StartTime", DbColumnType.DateTime)
                    .AddColumn("EndTime", DbColumnType.DateTime)
                    .AddColumn("TotalTime", DbColumnType.Time)
                    .AddColumn("OTHours", DbColumnType.Time)
                    .AddColumn("PayCycleId", DbColumnType.Short)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Pay Cycle Attendance
        public static DataTable PayCycleAttendance
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("PayCycleAttendanceId", DbColumnType.Int)
                    .AddColumn("PayCycleId", DbColumnType.Short)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("EmployeeLevelId", DbColumnType.Short)
                    .AddColumn("CalendarDays", DbColumnType.Decimal)
                    .AddColumn("WorkingDays", DbColumnType.Decimal)
                    .AddColumn("Leaves", DbColumnType.Decimal)
                    .AddColumn("Attended", DbColumnType.Decimal)
                     .AddColumn("OTHours", DbColumnType.Decimal)
                    .AddColumn("HOTHours", DbColumnType.Decimal)
                    .AddColumn("HolidaysWorked", DbColumnType.Decimal)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);
                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region SalaryProcessSetup
        public static DataTable SalaryProcessSetupType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SalaryProcessSetupId", DbColumnType.Int)
                    .AddColumn("SalaryCycleTypeId", DbColumnType.Int)
                    .AddColumn("DayCalculations", DbColumnType.Decimal)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region Process Salary
        public static DataTable ProcessSalary
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ProcessSalaryId", DbColumnType.Int)
                    .AddColumn("ProcessDate", DbColumnType.DateTime)
                    .AddColumn("ReleasedDate", DbColumnType.DateTime)
                    .AddColumn("IsOnHold", DbColumnType.Bool)
                    .AddColumn("LocationId", DbColumnType.Int)

                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("EmployeeLevelId", DbColumnType.Int)
                    .AddColumn("ApprisalYearId", DbColumnType.Int)
                    .AddColumn("PayCycleId", DbColumnType.Int)
                    .AddColumn("PayCalculationModeId", DbColumnType.Int)
                    .AddColumn("StartDate", DbColumnType.DateTime)
                    .AddColumn("EndDate", DbColumnType.DateTime)
                    .AddColumn("Gross", DbColumnType.Decimal)
                    .AddColumn("Net", DbColumnType.Decimal)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable ProcessSalaryDetail
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ProcessSalaryDetailId", DbColumnType.Int)
                    .AddColumn("ProcessSalaryId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("SalaryComponentId", DbColumnType.Int)
                    .AddColumn("Amount", DbColumnType.Decimal);

                foreach (var item in columnCollection) result.Columns.Add(item);
                return result;
            }
        }

        public static DataTable LeaveBankDetails
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LeaveBankId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("EmployeeLevelId", DbColumnType.Short)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("LeaveTypeId", DbColumnType.Short)
                    .AddColumn("PayCycleId", DbColumnType.Int)
                    .AddColumn("FrequencyLookupId", DbColumnType.Int)
                    .AddColumn("EarnedFromDate", DbColumnType.DateTime)
                    .AddColumn("EarnedLeaves", DbColumnType.Decimal)
                    .AddColumn("CarryForwardLeaves", DbColumnType.Decimal)
                    .AddColumn("NetLeaves", DbColumnType.Decimal)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region SalaryCycleType
        public static DataTable SalaryCycleType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SalaryCycleTypeId", DbColumnType.Int)
                    .AddColumn("Mode", DbColumnType.String)
                    .AddColumn("StartDate", DbColumnType.DateTime)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region Salary Advance
        public static DataTable SalaryAdvance
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SalaryAdvanceId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("AdvanceTypeLookupId", DbColumnType.Int)
                    .AddColumn("AdvanceDate", DbColumnType.DateTime)
                    .AddColumn("Amount", DbColumnType.Decimal)
                    .AddColumn("AdvanceApprovalStatusLookupId", DbColumnType.Int)
                    .AddColumn("Reason", DbColumnType.String)
                    .AddColumn("ApprovedBy", DbColumnType.Int)
                    .AddColumn("ApprovalComments", DbColumnType.String)
                    .AddColumn("RepayFromDate", DbColumnType.DateTime)
                    .AddColumn("NoOfInstallments", DbColumnType.Int)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Salary Advance Installment
        public static DataTable SalaryAdvanceInstallment
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SalaryAdvanceInstallmentId", DbColumnType.Int)
                    .AddColumn("SalaryAdvanceId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("InstallmentNo", DbColumnType.Short)
                    .AddColumn("Amount", DbColumnType.Decimal)
                    .AddColumn("PayCycleId", DbColumnType.Int)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region EmployeeLevel
        public static DataTable EmployeeLevelType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("EmployeeLevelId", DbColumnType.Short)
                    .AddColumn("LevelType", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("IsActive", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #endregion

        #region ClaimRule
        public static DataTable ClaimRule
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ClaimRuleId", DbColumnType.Int)
                    .AddColumn("ClaimTypeId", DbColumnType.Int)
                    .AddColumn("ApprisalYearId", DbColumnType.Int)
                    .AddColumn("EmployeeLevelId", DbColumnType.Int)
                    .AddColumn("Limit", DbColumnType.Decimal)
                    .AddColumn("FrequencyLookupId ", DbColumnType.Int)
                    .AddColumn("IsTaxBenefit", DbColumnType.Bool)
                    .AddColumn("MaxTaxBenefitLimit", DbColumnType.Decimal)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region LeaveRule
        public static DataTable LeaveRule
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LeaveRuleId", DbColumnType.Int)
                    .AddColumn("EarnLeaveConfigId", DbColumnType.Int)
                    .AddColumn("GenderLookupId", DbColumnType.Int)
                    .AddColumn("ExpInMonths", DbColumnType.Short)


                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region ClaimType
        public static DataTable ClaimType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ClaimTypeId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion        

        #region PayCycle 
        public static DataTable PayCycle
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection

                    .AddColumn("PayCycleId ", DbColumnType.Int)
                    .AddColumn("Title ", DbColumnType.String)
                    .AddColumn("ApprisalYearId ", DbColumnType.Short)
                    .AddColumn("PayCycleLookupId ", DbColumnType.Int)
                    .AddColumn("CalculateModeLookupId ", DbColumnType.Int)
                    .AddColumn("StartDate ", DbColumnType.DateTime)
                    .AddColumn("EndDate ", DbColumnType.DateTime)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region State
        public static DataTable State
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("StateId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region City
        public static DataTable City
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("CityId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("StateId", DbColumnType.Short)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                     .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region OT Config
        public static DataTable OTConfigType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("OTConfigId", DbColumnType.Int)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("EmployeeLevelId", DbColumnType.Short)
                    .AddColumn("OTHour", DbColumnType.String)
                    .AddColumn("HolidayHour", DbColumnType.String)
                    .AddColumn("OTHolidayHour", DbColumnType.String)
                    .AddColumn("BufferedHours", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region SG CPF
        public static DataTable SgCpfType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SGCPFId", DbColumnType.Int)
                    .AddColumn("CPFTypeLookupId", DbColumnType.Int)
                    .AddColumn("AgeFrom", DbColumnType.Int)
                    .AddColumn("AgeTo", DbColumnType.Int)
                    .AddColumn("CPFEmployerShare", DbColumnType.Decimal)
                    .AddColumn("CPFEmployeeShare", DbColumnType.Decimal)
                    .AddColumn("MaxAmount", DbColumnType.Decimal)
                    .AddColumn("MinAmount", DbColumnType.Decimal)
                    .AddColumn("SalaryFrom", DbColumnType.Decimal)
                    .AddColumn("SalaryTo", DbColumnType.Decimal)
                    .AddColumn("CPFBasedOnLookupId", DbColumnType.Int)
                    .AddColumn("TotalPercentage", DbColumnType.Decimal)
                    .AddColumn("MaxEmployeeShare", DbColumnType.Decimal)
                    .AddColumn("MaxEmployerShare", DbColumnType.Decimal)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region ApplyClaim
        public static DataTable ApplyClaim
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ApplyClaimId", DbColumnType.Int)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("ClaimTypeId", DbColumnType.Short)
                    .AddColumn("Amount", DbColumnType.Decimal)
                    .AddColumn("ClaimApprovalStatusLookupId", DbColumnType.Int)
                    .AddColumn("BillPath ", DbColumnType.String)
                    .AddColumn("BillNumber", DbColumnType.String)
                    .AddColumn("PaidTo", DbColumnType.String)
                    .AddColumn("BillDate", DbColumnType.DateTime)
                    .AddColumn("Remarks", DbColumnType.String)
                    .AddColumn("ApprovedById", DbColumnType.Int)
                    .AddColumn("ApprovalComments", DbColumnType.String)
                    .AddColumn("ApprovedDate", DbColumnType.DateTime)
                    .AddColumn("ProcessedCycleId", DbColumnType.Int)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Academic

        #region Class
        public static DataTable Class
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("ClassId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("NextClassId", DbColumnType.Short)
                    .AddColumn("IsGroup", DbColumnType.Bool)
                     .AddColumn("ParentId", DbColumnType.Short)
                    .AddColumn("IsActive", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);



                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region AcademicYear
        public static DataTable AcademicYear
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("AcademicYearId", DbColumnType.Int)
                    .AddColumn("FromDate", DbColumnType.DateTime)
                    .AddColumn("ToDate", DbColumnType.DateTime)
                    .AddColumn("IsAdmissionsClosed", DbColumnType.Bool)
                    .AddColumn("IsAdvancedAdmission", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);



                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Location
        public static DataTable Location
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("LocationId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("IsActive", DbColumnType.Bool)
                      .AddColumn("ParentId", DbColumnType.Int)
                    .AddColumn("Description", DbColumnType.String)


                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);



                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Subject
        public static DataTable SubjectType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("SubjectId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                     .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Specialisation
        public static DataTable SpecialisationType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("SpecialisationId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                     .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Semester
        public static DataTable SemesterType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("SemesterId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("NoOfMonths", DbColumnType.Short)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                     .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Fee
        public static DataTable FeeReceiptInput
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ReceiptType", DbColumnType.String)
                    .AddColumn("PupilId", DbColumnType.Int)
                    .AddColumn("AcademicYearId", DbColumnType.Int)
                    .AddColumn("ComponentTypeSequenceId", DbColumnType.Int)
                    .AddColumn("FeeOrganizationId", DbColumnType.Long)
                    .AddColumn("DcrDate", DbColumnType.DateTime)
                    .AddColumn("ModeOfPaymentId", DbColumnType.Int)
                    .AddColumn("Amount", DbColumnType.Int)
                    .AddColumn("ReceiptStatusId", DbColumnType.Int)
                    .AddColumn("Remarks", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable FeeSummary
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ComponentTypeSequenceId", DbColumnType.Int)
                    .AddColumn("ComponentTypeId", DbColumnType.Long)

                    .AddColumn("AcademicYearId", DbColumnType.Int)
                    .AddColumn("ComponentId", DbColumnType.Long)

                    .AddColumn("OrganizationId", DbColumnType.Long)

                    .AddColumn("FeeAmount", DbColumnType.Int)
                    .AddColumn("Collected", DbColumnType.Int)
                    .AddColumn("Refunded", DbColumnType.Int)
                    .AddColumn("Concession", DbColumnType.Int)
                    .AddColumn("DueAmount", DbColumnType.Int)
                    .AddColumn("NowPaid", DbColumnType.Int);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable FeeReceiptCheque
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("FeeReceiptChequeId", DbColumnType.Long)
                    .AddColumn("FeeReceiptId", DbColumnType.Long)

                    .AddColumn("ChequeNo", DbColumnType.String)
                    .AddColumn("ChequeDate", DbColumnType.DateTime)

                    .AddColumn("IFSC", DbColumnType.String)
                    .AddColumn("BankName", DbColumnType.String)
                    .AddColumn("BankCode", DbColumnType.String)
                    .AddColumn("BankBranch", DbColumnType.String)
                    .AddColumn("BankBranchAddress", DbColumnType.String)

                    .AddColumn("CardAuthorizationCode", DbColumnType.String)
                    .AddColumn("CardReferenceNumber", DbColumnType.String)

                    .AddColumn("ChequeStatusId", DbColumnType.Short)
                    .AddColumn("string", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Section
        public static DataTable SectionType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("SectionId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("IsActive", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                     .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Fee Setup
        public static DataTable FeeSetupType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("FeeSetupId", DbColumnType.Short)
                    .AddColumn("AcademicYearId", DbColumnType.Short)
                    .AddColumn("FeeComponentId", DbColumnType.Short)
                    .AddColumn("LocationId", DbColumnType.Short)
                    .AddColumn("ClassId", DbColumnType.Short)
                    .AddColumn("SpecialisationId", DbColumnType.Short)
                    .AddColumn("SemesterId", DbColumnType.Short)
                    .AddColumn("StudentTypeId", DbColumnType.Short)
                    .AddColumn("FeeOrganizationId", DbColumnType.Short)
                    .AddColumn("NewPupilFee", DbColumnType.Int)
                    .AddColumn("ExistingPupilFee", DbColumnType.Int)
                    .AddColumn("DueDate", DbColumnType.DateTime)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion


        #region Route
        public static DataTable Route
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("RouteId", DbColumnType.Short)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("VehicleId", DbColumnType.Short)
                    .AddColumn("LocationId", DbColumnType.Short)
                    .AddColumn("AcademicYearId", DbColumnType.Short)
                    .AddColumn("IsGroup", DbColumnType.Bool)
                    .AddColumn("ParentId", DbColumnType.Short)
                    .AddColumn("IsActive", DbColumnType.Bool);


                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion


        #region BigIntType
        public static DataTable BigIntType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("BigIntValue", DbColumnType.Long);


                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion


        #endregion

        #region Setting
        public static DataTable SettingType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("SettingsId", DbColumnType.Int)
                    .AddColumn("OrganizationId", DbColumnType.Short)
                    .AddColumn("FinancialYearId", DbColumnType.Short)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("AcademicYearId", DbColumnType.Short)
                    .AddColumn("SettingsTypeId", DbColumnType.Short)
                    .AddColumn("SettingValue", DbColumnType.String)
                    .AddColumn("Password", DbColumnType.String)

                     .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDateTime", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDatetime", DbColumnType.DateTime);
                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region TaxSetUp
        public static DataTable TaxSetup
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("TaxSetupId", DbColumnType.Int)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("GenderLookupId", DbColumnType.Int)
                    .AddColumn("AgeFrom", DbColumnType.Int)
                    .AddColumn("AgeTo", DbColumnType.Int)
                    .AddColumn("FromAmount", DbColumnType.Decimal)
                    .AddColumn("ToAmount", DbColumnType.Decimal)
                    .AddColumn("TaxPercentage", DbColumnType.Decimal)


                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region TaxExcemption
        public static DataTable TaxExcemption
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("TaxExcemptionId", DbColumnType.Int)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("TaxComponentId", DbColumnType.Int)
                    .AddColumn("MaxLimit", DbColumnType.Decimal)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Tax Declaration
        public static DataTable TaxDeclaration
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("TaxDeclarationId", DbColumnType.Int)
                    .AddColumn("TaxComponentId", DbColumnType.Int)
                    .AddColumn("ApprisalYearId", DbColumnType.Short)
                    .AddColumn("EmployeeId", DbColumnType.Int)
                    .AddColumn("Amount", DbColumnType.Decimal)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Tax Component
        public static DataTable TaxComponent
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("TaxComponentId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("LevelId", DbColumnType.Byte)
                    .AddColumn("ParentId", DbColumnType.Int)
                    .AddColumn("SortId", DbColumnType.Int)
                    .AddColumn("IsReadOnly", DbColumnType.Bool)
                    .AddColumn("IsActive", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Customers
        public static DataTable Customers
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("CustomerId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("Code", DbColumnType.String)
                    .AddColumn("AccountHeadId", DbColumnType.Int)
                    .AddColumn("AccountGroupId", DbColumnType.Int)
                    .AddColumn("CreditLimit", DbColumnType.Decimal)
                    .AddColumn("CreditDays", DbColumnType.Int)
                    .AddColumn("AccountTypeId", DbColumnType.Byte)
                    .AddColumn("JsonFeed", DbColumnType.String)
                    .AddColumn("CurrencyId", DbColumnType.Int)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region AccountTemplateDetails
        public static DataTable AccountTemplate
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("AccountTemplateId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("VoucherTypeId", DbColumnType.Short)
                    .AddColumn("VoucherSubTypeId", DbColumnType.Short)
                    .AddColumn("MainAccHeadKey", DbColumnType.String)
                    .AddColumn("MainAccHeadId", DbColumnType.Int)
                    .AddColumn("IsDeafult", DbColumnType.Bool)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable AccountTemplateDetail
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("AccountTemplateDetailId", DbColumnType.Int)
                    .AddColumn("AccountTemplateId", DbColumnType.Int)
                    .AddColumn("ByTo", DbColumnType.String)
                    .AddColumn("AccHeadId", DbColumnType.Int)
                    .AddColumn("AccHeadKeyCode", DbColumnType.String)
                    .AddColumn("Formula", DbColumnType.String)
                    .AddColumn("IsDetailedLevel", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);
                return result;
            }
        }
        #endregion

        #region ExamType
        public static DataTable ExamType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ExamTypeId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("SortingId", DbColumnType.Short)
                    .AddColumn("AcademicYearId", DbColumnType.Short)
                     .AddColumn("GradeTypeId", DbColumnType.Short)
                     .AddColumn("ExamCategoryId", DbColumnType.Short)
                    .AddColumn("PrintTemplateId", DbColumnType.Short);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion ExamType

        #region MapExamTypeAndClassCategory
        public static DataTable MapExamTypeAndClassCategory
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("MapExamTypeAndClassCategoryId", DbColumnType.Int)
                    .AddColumn("ExamTypeId", DbColumnType.Int)
                     .AddColumn("ClassId", DbColumnType.Short);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region MapExamTypeAndLocation
        public static DataTable MapExamTypeAndLocation
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("MapExamTypeAndLocationId", DbColumnType.Int)
                    .AddColumn("ExamTypeId", DbColumnType.Int)
                     .AddColumn("LocationId", DbColumnType.Short);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region MapExamTypeAndTemplate
        public static DataTable MapExamTypeAndTemplate
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("MapExamTypeAndTemplateId", DbColumnType.Int)
                    .AddColumn("SourceExamTypeId", DbColumnType.Int)
                    .AddColumn("PrintExamTypeId", DbColumnType.Short)
                    .AddColumn("SortId", DbColumnType.Short);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Grid Display Format
        public static DataTable GridDisplayFormatTable
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("GridDisplayFormatId", DbColumnType.Int)
                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("VoucherTypeId", DbColumnType.Int)

                    .AddColumn("DirectQuery", DbColumnType.String)
                    .AddColumn("ParmsCondition", DbColumnType.String)
                    .AddColumn("OrderByCondition", DbColumnType.String)
                    .AddColumn("GroupByColumns", DbColumnType.String)
                    .AddColumn("ParmDatasetName", DbColumnType.String)

                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region ExamSchedule
        public static DataTable ExamSchedule
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ExamScheduleId", DbColumnType.Int)
                    .AddColumn("PaperTitle", DbColumnType.String)
                    .AddColumn("ExamTypeId", DbColumnType.Int)
                    .AddColumn("ClassId", DbColumnType.Short)
                     .AddColumn("MaximunMarks", DbColumnType.Short)
                     .AddColumn("GradeTypeId", DbColumnType.Short)
                    .AddColumn("IsIncludeInTotal", DbColumnType.Bool)
                  .AddColumn("BaseMark", DbColumnType.Short)
                 .AddColumn("SortingId", DbColumnType.Short)
                   .AddColumn("ShowDetail", DbColumnType.Bool)
                   .AddColumn("IsGrade", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion ExamSchedule

        #region ExamScheduleLink
        public static DataTable ExamScheduleLink
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ExamScheduleLinkId", DbColumnType.Int)
                    .AddColumn("ExamScheduleId", DbColumnType.Int)
                    .AddColumn("ExamSchedulePaperId", DbColumnType.Int)
                   .AddColumn("BaseMarks", DbColumnType.Short);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion ExamScheduleLink

        #region ExamSchedule
        public static DataTable ExamSchedulePaper
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("ExamSchedulePaperId", DbColumnType.Int)
                    .AddColumn("ExamScheduleId", DbColumnType.String)
                    .AddColumn("ExamDate", DbColumnType.DateTime)
                    .AddColumn("SubjectId", DbColumnType.Short)
                     .AddColumn("AlternateSubjectId", DbColumnType.Short)
                     .AddColumn("PaperTypeId", DbColumnType.Short)
                    .AddColumn("IsIndependentPassRequired", DbColumnType.Bool)
                  .AddColumn("MaximunMarks", DbColumnType.Short)
                 .AddColumn("BaseMarks", DbColumnType.Short)
                   .AddColumn("GradeTypeId", DbColumnType.Short)
                   .AddColumn("PaperId", DbColumnType.Short)
                 .AddColumn("IncludedInTotal", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion ExamSchedule

        #region DcrDeposit
        public static DataTable DcrDeposit
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("DcrDepositId", DbColumnType.Int)
                    .AddColumn("ReceiptDate", DbColumnType.DateTime)
                    .AddColumn("LocationId", DbColumnType.Short)
                    .AddColumn("ComponentTypeId", DbColumnType.Short)
                    .AddColumn("FeeOrganizationId", DbColumnType.Short)
                    .AddColumn("ModeOfPaymentId", DbColumnType.Short)
                   .AddColumn("AccountHeadId", DbColumnType.Int)
                   .AddColumn("CounterfoilNo", DbColumnType.String)
                   .AddColumn("Amount", DbColumnType.Int)
                   .AddColumn("Remarks", DbColumnType.String)
                   .AddColumn("DepositedDate", DbColumnType.DateTime)
                   .AddColumn("ApprovedDateTime", DbColumnType.DateTime)
                   .AddColumn("ApprovedBy", DbColumnType.Int)
                   .AddColumn("RecordCreatedBy", DbColumnType.Int)
                   .AddColumn("RecordCreatedDateTime", DbColumnType.DateTime)
                   .AddColumn("RecordModifiedBy", DbColumnType.Int)
                   .AddColumn("RecordModifiedDateTime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion DcrDeposit

        #region GradeType
        public static DataTable GradeType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("GradeTypeId", DbColumnType.Short)
                    .AddColumn("GradeTitle", DbColumnType.String)
                    .AddColumn("IsValid", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion 

        #region GradeTypeDetail
        public static DataTable GradeTypeDetail
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("GradeTypeDetailId", DbColumnType.Int)
                    .AddColumn("GradeTypeId", DbColumnType.Short)
                    .AddColumn("FromValue", DbColumnType.Decimal)
                    .AddColumn("ToValue", DbColumnType.Decimal)
                    .AddColumn("Grade", DbColumnType.String)
                    .AddColumn("Points", DbColumnType.Short)
                    .AddColumn("IsPassed", DbColumnType.Bool);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        #region Pupil
        public static DataTable Pupil
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("PupilId", DbColumnType.Int)
                    .AddColumn("EnquiryId", DbColumnType.Int)
                    .AddColumn("AdmissionNumber", DbColumnType.String)
                    .AddColumn("FirstName", DbColumnType.String)
                    .AddColumn("LastName", DbColumnType.String)
                    .AddColumn("FatherName", DbColumnType.String)
                    .AddColumn("MobileNumber", DbColumnType.String)

                    .AddColumn("DoB", DbColumnType.DateTime)
                    .AddColumn("DoJ", DbColumnType.DateTime)
                    .AddColumn("GenderId", DbColumnType.Int)

                    .AddColumn("UniqueId", DbColumnType.UniqueIdentifier)

                    .AddColumn("JsonFeed", DbColumnType.String)
                    ;

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable PupilAcademicPosition
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                    .AddColumn("PupilAcademicPositionId", DbColumnType.Int)
                    .AddColumn("PupilId", DbColumnType.Int)

                    .AddColumn("AcademicYearId", DbColumnType.Int)
                    .AddColumn("LocationId", DbColumnType.Int)
                    .AddColumn("ClassId", DbColumnType.Int)
                    .AddColumn("SectionId", DbColumnType.Int)

                    .AddColumn("StudentTypeId", DbColumnType.Int)
                    .AddColumn("SpecialisationId", DbColumnType.Int)

                    .AddColumn("RollNo", DbColumnType.Int)

                    .AddColumn("IsNewStudent", DbColumnType.Bool)
                    .AddColumn("AcademicPositionStatusId", DbColumnType.Int)
                    .AddColumn("ReleaseDate", DbColumnType.DateTime)
                    .AddColumn("JsonFeed", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion

        public static DataTable CommunicationAddress
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("CommunicationAddressId", DbColumnType.Int)
                    .AddColumn("Source", DbColumnType.String)
                    .AddColumn("AddressType", DbColumnType.String)
                    .AddColumn("SourceRefId", DbColumnType.Int)
                    .AddColumn("Address", DbColumnType.String)

                    .AddColumn("CityId", DbColumnType.Int)
                    .AddColumn("StateId", DbColumnType.Int)
                    .AddColumn("CountryId", DbColumnType.Int)

                    .AddColumn("JsonFeed", DbColumnType.String);

                //.AddColumn("CreatedBy", DbColumnType.Int)
                //.AddColumn("CreatedDateTime", DbColumnType.DateTime)
                //.AddColumn("ModifiedBy", DbColumnType.Int)
                //.AddColumn("ModifiedDatetime", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        #region Workflow
        public static DataTable Workflow
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("WorkflowId", DbColumnType.Int)
                    .AddColumn("Title", DbColumnType.String)

                    .AddColumn("DataSetId", DbColumnType.Int)
                    .AddColumn("VoucherTypeId", DbColumnType.Int)

                    .AddColumn("RawCondition", DbColumnType.String)
                    .AddColumn("ConditionJsonFeed", DbColumnType.String)
                    .AddColumn("JsonFeed", DbColumnType.String)

                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        public static DataTable WorkflowAction
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("WorkflowActionId", DbColumnType.Int)
                    .AddColumn("WorkflowId", DbColumnType.Int)

                    .AddColumn("Title", DbColumnType.String)
                    .AddColumn("UniqueId ", DbColumnType.UniqueIdentifier)
                    .AddColumn("ActivityTypeId", DbColumnType.Byte)

                    .AddColumn("RawCondition", DbColumnType.String)
                    .AddColumn("ConditionJsonFeed", DbColumnType.String)
                    .AddColumn("JsonFeed", DbColumnType.String)
                    .AddColumn("SortId", DbColumnType.Int);
                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable WfApprovalActivitySetup
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("WfApprovalActivitySetupId", DbColumnType.Int)

                    .AddColumn("WorkflowId", DbColumnType.Int)
                    .AddColumn("ActivityGuid", DbColumnType.UniqueIdentifier)

                    .AddColumn("ActionGroups", DbColumnType.String)
                    .AddColumn("ActivityLookupId", DbColumnType.Int)
                    .AddColumn("DefaultActivityLookupValueId", DbColumnType.Int)
                    .AddColumn("LookupFieldMapping", DbColumnType.String)

                    .AddColumn("ApprovedActions", DbColumnType.String)
                    .AddColumn("ApprovedNotify", DbColumnType.String)

                    .AddColumn("RejectedActions", DbColumnType.String)
                    .AddColumn("RejectedNotify", DbColumnType.String)

                    .AddColumn("PendingActions", DbColumnType.String)
                    .AddColumn("PendingNotify", DbColumnType.String)

                    .AddColumn("UpdateStatus", DbColumnType.Bool)
                    .AddColumn("UpdateLinks", DbColumnType.Bool)
                    .AddColumn("UpdateInventory", DbColumnType.Bool)
                    .AddColumn("UpdateAccounting", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);
                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }

        public static DataTable WfNotificationActivitySetup
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("WfNotificationActivitySetupId", DbColumnType.Int)
                    .AddColumn("WorkflowId", DbColumnType.Int)
                    .AddColumn("ActivityGuid", DbColumnType.UniqueIdentifier)
                    .AddColumn("NotificationGroups", DbColumnType.String)

                    .AddColumn("Email", DbColumnType.Bool)
                    .AddColumn("TextMessage", DbColumnType.Bool)
                    .AddColumn("Whatsapp", DbColumnType.Bool)
                    .AddColumn("CreatedBy", DbColumnType.Int)
                    .AddColumn("CreatedDate", DbColumnType.DateTime)
                    .AddColumn("ModifiedBy", DbColumnType.Int)
                    .AddColumn("ModifiedDate", DbColumnType.DateTime);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        public static DataTable WfApprovalActivityType
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();

                columnCollection
                    .AddColumn("WfApprovalActivityId", DbColumnType.Long)
                    .AddColumn("WorkflowTrackLogId", DbColumnType.Long)
                    .AddColumn("SelectedLookupDetailId", DbColumnType.Int)
                    .AddColumn("ApprovedComments", DbColumnType.String);

                foreach (var item in columnCollection) result.Columns.Add(item);

                return result;
            }
        }
        #endregion
        #region Student
        public static DataTable Attendance
        {
            get
            {
                var result = new DataTable();
                var columnCollection = new DataColumnCollection();
                columnCollection
                .AddColumn("AttendanceId", DbColumnType.Long)
                .AddColumn("Id", DbColumnType.Int)
                .AddColumn("AttendanceDate", DbColumnType.DateTime)
                .AddColumn("Option_01", DbColumnType.Bool)
                .AddColumn("Option_02", DbColumnType.Bool)
                .AddColumn("Option_03", DbColumnType.Bool)
                .AddColumn("Option_04", DbColumnType.Bool)
                .AddColumn("Option_05", DbColumnType.Bool)
                .AddColumn("Option_06", DbColumnType.Bool)
                .AddColumn("Option_07", DbColumnType.Bool)
                .AddColumn("Option_08", DbColumnType.Bool)
                .AddColumn("Option_09", DbColumnType.Bool)
                .AddColumn("Option_10", DbColumnType.Bool)
                .AddColumn("Total", DbColumnType.Decimal);
                foreach (var item in columnCollection)
                    result.Columns.Add(item);

                return result;
            }
        }
        #endregion
    }
}