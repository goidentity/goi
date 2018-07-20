export class AccountTemplateDetails {
    public AccountTemplate: AccountTemplate;
    public AccountTemplateDetail: AccountTemplateDetail[];
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

