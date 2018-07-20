export class ArAp {
    public ArApId: number;
    public UniqueId: string;
    public TransactionType: string;

    public DocNo: string;
    public DocDate: Date;
    public DueDate: Date;

    public DataSetOrVoucherTypeId: number;
    public SourceId: number;

    public AccountHeadId: number;
    public CustomerId: number;

    public Amount: number;
    public CurrencyId: number;
    public ExchangeRate: number
    public ExchangeAmount: number;

    public ReferenceId: number;
    public PendingAmount: number;
    public R_P: string;
    public OnAccountAmount: number;
    public ExchangeOnAccountAmount: number;
}

export class vArApSummary extends ArAp {
    public PendingAmount: number;
    public PendingEAmount: number;
    public AdjustedAmount: number;
    public NewAmount: number 

    public ExchangeNewAmount: number 
}

export class ApApDialogData {
    public R_P: string;
    public CustomerOrSupplierName: string;
    public NewReferenceAmount: number;
    public OnAccountAmount: number;

    public ExchangeNewReferenceAmount: number;
    public ExchangeOnAccountAmount: number;

    constructor() {
        this.ArApItems = [];
    }

    public ArApItems: Array<vArApSummary>
}