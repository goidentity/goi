import { TreeItem } from 'ngx-treeview';
import { Observable } from 'rxjs';

export class ReportCol {
    public ReportColId: number;
    public ReportDocumentId: number;
    public ObjectName: string;
    public ColName: string;
    public ParsedColName: string;
    public DisplayName: string;
    public AggregateFunctionLookupId: number;
    public ColumnDataTypeLookupId: number;

    public IsGroup: boolean;
    //public IsNumber: boolean;
    public GrandTotal: boolean;
    public SubTotal: boolean;
    public SortId: number;

    public MinWidth: number;
    public MaxWidth: number;

    public IsHidden: boolean;
    public DisplayFormat: string;
    public TextAlignLookupId: number;

    public GroupName: number;


    public FilterType: string;
}

export class ReportDocument {
    public ReportDocumentId: number;
    public Title: string;
    public IsWidget: boolean;
    public ReportTypeLookupId: number;
    public ReportLayoutLookupId: number;

    public Category: string;
    public ReportParmDatasetName: string;
    public SubReportDocumentId: number;

    public Conditions: string;
    public DirectQuery: string;
    public DirectQueryOrderBy: string;

    public SqlQuery: string;

    public PivotRows: string;
    public PivotColumns: string;
    public PivotValues: string;

    public GroupByColumns: string;

    public PivotRowsArray: Array<string>;
    public PivotColumnsArray: Array<string>;
    public PivotValuesArray: Array<string>;

    public GroupByColumnsArray: Array<string>;
}

export class vReportDoc extends ReportDocument {
    public ReportType: string;
    public Layout: string;
    public Parms: string;
}

export class ReportTableMapping {
    public ReportTableMappingId: number;
    public ReportDocumentId: number;
    public ReportJoinTypeLookupId?: number;
    public ObjectName: string;
    public Alias: string;
    public SortId: number;
    public Condition: string;
}

export class ReportColGroup {
    public GroupName: string;
    public Cols: Array<ReportCol>;
}

export class SuiteReport {
    public MenuTitle: string;
    public DependentOn: string;
    public RedirectPath: string;

    public ModuleId: number;
    public NavigationGroupId: number;

    public Doc: ReportDocument;
    public Mappings: ReportTableMapping[];
    public Cols: ReportCol[];

    public TrimmedCols: ReportCol[];
    public ReportColGroups: ReportColGroup[];
}

export class DbObjectField {
    public ObjectName: string;
    public ColName: string;
    public ColType: string;
    public SchemaName: string;
    public DisplayName: string;
}

export class ReportSource {
    public ReportSourceId: number;
    public Title: string;
    public ViewName: string;
    public SqlQuery: string;
}


/* Dashboard */
export class DashboardHeader {
    public DashboardHeaderId: number;
    public DisplayTitle: string;
    public DashboardParmDatasetName: string;
    public JsonFeed: string;
    public IsActive: boolean;
}

export class DashboardDetail {
    public DashboardDetailId: number;
    public DashboardHeaderId: number;
    public ReportDocumentId: number;
}

export class DashboardDocument {
    public MenuTitle: string;
    public DependentOn: string;
    public RedirectPath: string;

    public ModuleId: number;
    public NavigationGroupId: number;

    public Header: DashboardHeader;
    public Details: DashboardDetail[];

    public WidgetsList: DashboardRowIdList[];

    public Rows: DashboardRow[];
}

export class DashboardRowIdList {
    public WidgetIds: number[];
}

export class DashboardRow {
    constructor() {
        this.ReportDocs = [];
    }
    public ReportDocs: vReportDoc[];
}

export class ChartModal {
    constructor() {
        this.Category = [];
        this.Data = [];
    }

    public Category: CategoryAxis[];
    public Data: DataAxis[];
}

export class CategoryAxis {
    constructor() {
        this.Data = [];
    }

    public Title: string;
    public Data: string[];
}

export class DataAxis {
    constructor() {
        this.Data = [];
    }

    public Title: string;
    public Data: any[];
}

export class DoubleAxis {
    public Title: string;
    public Data: number;
}
export class ExportReportFeed {
    Col: ColData[];
    //Group: string;
    //Sort: string;
    constructor() {
        this.Col = [];
    }
}
export class ColData {
    

    constructor(public ColName: string, public DisplayName: string, public IsDisplay: boolean) {
    }
}