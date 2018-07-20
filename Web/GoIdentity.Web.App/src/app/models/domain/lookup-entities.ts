export class LookUp {
    public LookupId: number;
    public OrganizationId: number;
    public Title: string;
    public IsActive: boolean = true;
    public IsReadOnly: boolean;
    public SortType: number;
    public Category: string;
    public ChequeStatus: boolean;

}

export class LookUpDetail {
    public LookupDetailId: number;
    public LookupId: number;
    public Value: string;
    public SequenceId: number;
    public SortId: number;
    public IsActive: boolean = true;
    public ChequeStatus: string;
}

export class LookupString {
    public Value: string;
    public Title: string;

    constructor(value: string, title: string) {
        this.Value = value;
        this.Title = title;
    }
}