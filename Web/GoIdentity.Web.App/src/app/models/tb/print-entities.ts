import { TreeItem } from 'ngx-treeview';
import { Observable } from 'rxjs';

export class PrintTableMapping {
    public PrintTableMappingId: number;
    public PrintDocumentId: number;
    public ObjectName: string;
    public Alias: string;
    public Condition: string;
}

export class PrintDocument {
    public PrintDocumentId: number;
    public Title: string;
    public PrintSourceLookupTypeId: number;

    public DataSetId?: number;
    public VoucherTypeId?: number;
    public OtherSource: string;

    public PrintTypeLookupId: number;
    public PrintPageSizeLookupId: number;
    public Height: number;
    public Width: number;

    public FontFamily: string;
    public FontSize: number;

    public IsDefault: boolean;
    public JsonFeed: string;

    public Form: PrintForm;
    public Mappings: PrintTableMapping[];

    constructor() {
        this.Mappings = [];
    }
}

export class vPrintDocument extends PrintDocument {
    public PrintSource: string;
    public DataSet: string;
    public VoucherType: string;
    public PrintType: string;
    public PrintPageSize: string;
}

export class TextFormatSettings {
    public FontFamily: string;
    public FontSize: string;
    public FontType: string;

    public BackgroundColor: string;
    public ForegroundColor: string;

    public Width: string;
    public Height: string;
    public Align: string;
    public WrapText: boolean;
    public Display: string;
    public Float: string;
    public Transform: string;
    public Position: string;
    public Top: string;
    public Left: string;

    public Padding: string;
    public Margin: string;
    public Border: string;
    


    constructor() { }
}

export class PrintCol extends TextFormatSettings {
    public Text: string;
    public Field: string;
    public ImageSource: string;
    public Formula: string;
    public Format: string;
    public ColsMode: string;

    public ConvertToWords: boolean;
    public RequireTotal: boolean;

    public ImageUrl: string;
    public AutoSno: boolean;
}

export class PrintRow extends TextFormatSettings {
    public Cols: PrintCol[];

    constructor() {
        super();
        this.Cols = [];
    }
}

export class PrintImage extends TextFormatSettings {
    public Text: string;
    public Field: string;
    public ImageSource: string;
    public Formula: string;
    public Format: string;

    public RequireTotal: boolean;
}

export class PrintFrame extends TextFormatSettings {
    public Mode: string;
    public SourceTypeId: number;
    public DataContext: string
    public Parms: string

    public Cols: PrintCol[];
    public Rows: PrintRow[];

    constructor() {
        super();
        this.Cols = [];
        this.Rows = [];
    }
}

export class PrintForm {
    public Frames: PrintFrame[];

    constructor() {
        this.Frames = [];
    }
}

export class PrintParm {
    public ParmName: string;
    public ParmValue: string;
}

export class BuildPrintDocumentResponse {
    public Data: string;
}
