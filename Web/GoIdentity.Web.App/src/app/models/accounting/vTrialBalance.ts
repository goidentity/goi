export class vTrialBalance {
    public AccountHeadId: number
    public AccountName: string
    public IsGroup: boolean
    public VoucherDate: Date
    public Debits: number
    public Credits: number
    public OpenDr: number
    public OpenCr: number
    public ClosingDr: number
    public ClosingCr: number

    public FromDate: Date
    public ToDate: Date
}

export class GetTrialBalanceResponse {
    TrialBalances: Array<vTrialBalance>;
    Total: number;
}

export class GetTrialBalanceRequest {
    constructor() {
        this.Take = 0;
        this.Skip = 0;
        this.SortList = new Array<SortDescriptor>();
        this.FilterList = new Array<FilterDescriptor>();
        this.TrialBalances = new vTrialBalance();
    }

    Skip: number;
    Take: number;


    SortList: Array<SortDescriptor>;
    FilterList: Array<FilterDescriptor>;

    TrialBalances: vTrialBalance;


    public clearAll(): void {
        this.SortList = new Array<SortDescriptor>();
        this.FilterList = new Array<FilterDescriptor>();
    }
}

export class SortDescriptor {
    Field: string;
    Dir: string;
}

export class FilterDescriptor {
    Field: string;
    Operator: string;
    Value: string;
}