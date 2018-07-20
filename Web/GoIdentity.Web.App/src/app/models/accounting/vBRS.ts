export class vBRS {
    public VoucherId: number;
    public VoucherDate: Date;
    public VoucherNumber: string;
    public BaseAmount: number;
    public ChequeNumber: string;
    public ChequeStatusId: number;
    public ChequeStatus: string;
    public ClearanceDate: Date;
    public ExchangeDebitAmount: number;
    public ExchangeCreditAmount: number;
    public ExchangeAmount: number;
    public DebitAmount: number;
    public CreditAmount: number;
    public Amount: number;
    public CurrencyId: number;
    public Title: string;
    public ExchangeRate: number;
    public AccountHeadId: number;
    public AccountName: string;

    public FromDate: Date;
    public ToDate: Date;

    public IsProcessed: boolean;
}

export class GetBRSResponse {
    BRS: Array<vBRS>;
    Total: number;
}
export class GetBRSRequest {
    constructor() {
        this.Take = 0;
        this.Skip = 0;
        this.SortList = new Array<SortDescriptor>();
        this.FilterList = new Array<FilterDescriptor>();
        this.BrsList = new vBRS();
    }
    Skip: number;
    Take: number;


    SortList: Array<SortDescriptor>;
    FilterList: Array<FilterDescriptor>;
    BrsList: vBRS;

    public clearAll(): void {
        this.SortList = new Array<SortDescriptor>();
        this.FilterList = new Array<FilterDescriptor>();
        this.BrsList = new vBRS();
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