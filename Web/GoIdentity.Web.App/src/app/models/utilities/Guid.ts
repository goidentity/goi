export class Guid {
    static newGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}

export class InputDataTypeConstants {
    public static readonly Int_Type: number = 1;
    public static readonly Decimal_Type: number = 2;
    public static readonly DateTime_Type: number = 3;
    public static readonly String_Type: number = 4;
    public static readonly Guid_Type: number = 5;
    public static readonly FileName_Type: number = 6;
    public static readonly Boolean_Type: number = 7;
}

export class InputControlTypeConstants {
    public static readonly TextBox: number = 1;
    public static readonly DropDownList: number = 2;
    public static readonly MultiSelect: number = 3;
    public static readonly Checkbox: number = 4;
    public static readonly DatePicker: number = 5;
    public static readonly Password: number = 6;
    public static readonly NumericTextBox: number = 7;
    public static readonly EmailTextBox: number = 8;
    public static readonly MaskedTextBox: number = 9;
    public static readonly PhotoUpload: number = 10;
    public static readonly FileUpload: number = 11;
    public static readonly AutoGenerate: number = 12;
    public static readonly TreeView: number = 13;
    public static readonly HiddenAutoGenerate: number = 14;
    public static readonly HiddenInput: number = 15;
    public static readonly MaskedInput = 16;
    public static readonly TextArea: number = 17;
}

export class InputSourceTypeConstants {
    public static readonly Manual_Type: number = 0;
    public static readonly Dataset_Type: number = 1;
    public static readonly Lookup_Type: number = 2;
    public static readonly Tables_Type: number = 3;
    public static readonly Functions_Type: number = 4;
}

export class KeyConstants {
    public static readonly LoadPageDataGrid: string = "LoadPageDataGrid";
    public static readonly PageDataGridSelectedItem: string = "PageDataGridSelectedItem";
    public static readonly PageDataGridEditItem: string = "PageDataGridEditItem";
    public static readonly PageDataGridDeleteItem: string = "PageDataGridDeleteItem";
    public static readonly PageDataGridPrintItem: string = "PageDataGridPrintItem";
    public static readonly BreadcrumbsTitle: string = "BreadcrumbsTitle";
    public static readonly RefreshReport: string = "RefreshReport";

    public static readonly Selected_Student: string = "Selected_Student";
    public static readonly Selected_Employee: string = "Selected_Employee";
    public static readonly Selected_Vehicle: string = "Selected_Vehicle";
}