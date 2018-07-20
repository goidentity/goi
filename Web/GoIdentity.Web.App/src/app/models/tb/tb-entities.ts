import { TreeItem } from 'ngx-treeview';
import { Observable } from 'rxjs';
import { GridDisplayFormat, GridColumn } from '../domain/common-entities';

export class DocumentDataSetDetail {
    public DataSetDetailId: number;
    public DataSetId: number;
    public KeyFieldName: string;
    public FieldName: string;
    public IsFixed: boolean;
    public InputDataTypeId: number;

    public DisplayTitle: string;
    public InputControlTypeId: number;

    public SourceTypeId: number;
    public Source: string;
    public DisplayField: string;
    public ValueField: string;
    public Parms: string;
    public Mask: string;
    public OtherOptions: string;

    public MinWidth?: number;
    public MaxWidth?: number;

    public MinHeight?: number;
    public MaxHeight?: number;

    public DefaultValue: string;

    public Formula: string;

    public Required: boolean;
    public IsTotalRequired: boolean;
    public IsParentMappField: boolean;
    public IsActive: boolean;
    public HideWhenNoData: boolean;
    public IsReadOnly: boolean;
    public IncludeDefaultValue: boolean;

    public DisabledWhen: string;

    public TriggerToLoadDetail: boolean;
    public SplitAmount: boolean;

    public Scope: string;
    public IsReadOnlyLocal: boolean;

    constructor() {
        this.IsActive = true;
        this.IsValid = true;
    }

    public IsValid: boolean = true;
    public InputControlTypeTitle: string;
    public DisplayFieldArray: Array<string>;
    public TempValue: any;

    public TempValue2: any;
    public TempValueArray: any[];
}

export class DocumentPanel {
    public Title: string;
    public Tables: DocumentTable[];
    public Fields: DocumentDataSetDetail[];

}
export class DocumentTable {
    public Title: string;
    public Panels: DocumentPanel[];
    public Fields: DocumentDataSetDetail[];
}

export class DocumentPanelLayouts {
    public Title: string;
    public Fields: DocumentDataSetDetail[];
    public Layouts: InputItems[];

}

export class DocumentFields {
    public Fields: DocumentDataSetDetail[];
    public Layouts: InputItems[];
}


export class DocumentRow {
    public Tables: DocumentTable[];
    public Panels: DocumentPanel[];
    public Fields: DocumentDataSetDetail[];
}

export class DocumentLayouts {
    public row: DocumentRow[];
}

export class DocumentDataSet {
    public DataSetId: number;
    public Name: string;

    public DisplayTitle: string;
    public ParentDataSetId: string;

    public IsReadOnly: boolean;
    public DataSetTypeLookupId: number;

    public Category: string;
    public DependentOn: string;
    public RedirectPath: string;

    public PageBannerId: number;
    public BannerParm: string;

    public FallbackPageBannerId: number;
    public FallbackBannerParm: string;

    public PostAction: string;
    public MaxRows: number;

    public DocumentLayoutLookupId: number;
    public ChildDataSetIds: string;

    public InventoryUpdateLookupId: number;
    public ArApUpdateLookupId: number;

    public IsActive: number;
}

export class DataSetDataFormatted {
    public Id: number;
    public UniqueId: string;
    public DataSetId: number;
    public DetailsDataSetId?: number;

    public HeaderFeed: string;
    public Header: any[];
    public DetailsFeed: string[];
    public Details_ExtFeed: string[];

    public Ds: DocumentDataSet;
}

export class vDocumentDataSet extends DocumentDataSet {
    constructor() {
        super();
        this.HideDataSet = true;
    }
    public InventoryUpdate: string;
    public ArApUpdate: string;
    public DocumentLayout: string;
    public DataSetType: string;

    public HideDataSet: boolean;
}

export class GetPageDocumentWithChildsResponse {
    public PageDoc: Doc;
    public ChildDataSets: vDocumentDataSet[];
}

export class Doc {
    public PageDocumentId: number;
    public DocumentTitle: string;
    public Category: string;

    public MenuTitle: string;
    public PageTitle: string;

    public ModuleId: number;
    public NavigationGroupId: number;

    public DataSetId?: number;
    public DataSetName: string;

    public PageBannerId?: number;
    public BannerParm: string;

    public DataBannerId?: number;
    public DataBannerParm: string;

    public FallbackPageBannerId?: number;
    public FallbackBannerParm: string;

    public DetailedDataSetId?: number;
    public DetailedDataSetName: string;

    public Detailed_ExtDataSetId?: number;
    public Detailed_ExtDataSetName: string;

    public PostAction: string;
    public MaxRows: number;

    public IsReadOnly: boolean;
    public DataSetTypeLookupId: number;
    public InventoryUpdateLookupId: number;
    public ArApUpdateLookupId: number;
    public DocumentLayoutLookupId: number;
    public ChildDataSetIds: string;
    public ChildDataSetIdsArray: Array<number>;

    public Header: DocumentRow[];
    public Footer: DocumentRow[];

    public Details: DocumentDataSetDetail[];
    public Details_Title: string;

    public Details_Ext: DocumentDataSetDetail[];
    public Details_Ext_Title: string;

    public DisplayFormat: GridDisplayFormat;
}

export class sourceList {
    public FieldName: string = "textbox";

}

export class InputItems {
    public type: string;
    public title: string;

}

export class Container {
    public id: number;
    public name: string;
    public widgets: Array<Widget>;
}

export class Widget {
    public name: string
}

export class InputDataType {
    constructor(inputDataTypeId: number, title: string) {
        this.InputDataTypeId = inputDataTypeId;
        this.Title = title;
    }
    public InputDataTypeId: number;
    public Title: string;
}

export class vFieldMetaList {
    public SourceTypeId: number;
    public SourceType: string;
    public Title: string;
    public FieldName: string;
}

export class TxnDataTreeItem implements TreeItem {
    public text: string;
    public value: any;
    public disabled?: boolean;
    public checked?: boolean;
    public collapsed?: boolean;
    public children?: TreeItem[];
}

export class AccountTemplate {
    public AccountTemplateId: number;
    public Title: string;
    public DataSetId: number;
    public VoucherTypeId: number;
    public VoucherSubTypeId: number;

    public MainAccHeadKey: string;
    public MainAccHeadId: number;

    public IsDeafult: boolean;

    public Details: AccountTemplateDetail[];
}

export class AccountTemplateDetail {
    public AccountTemplateDetailId: number;
    public AccountTemplateId: number;
    public ByTo: string;
    public AccHeadId: number;
    public AccHeadKeyCode: string;
    public Formula: string;
    public IsDetailedLevel: boolean;
}

export class vAccountTemplate extends AccountTemplate {
    public DataSetTitle: string;
    public VoucherType: string;
    public SubVoucherType: string;
    public AccHead: string;
}

export class ExternalParameter {
    public Name: string;
    public Value: string
}
