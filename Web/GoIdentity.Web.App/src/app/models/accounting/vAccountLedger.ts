export class vAccountLedger {
    public VoucherId: number;
    public VoucherDate: Date;
    public VoucherNumber: string;          
    public CreditAmount: number
    public DebitAmount: number
    public Balance: number
    public AccountHeadId: number
    public AccountName: string    

    public Title: String
    public FromDate: Date
    public ToDate: Date
        
}

export class GetAccountLedgersResponse{
    AccountLedgers: Array<vAccountLedger>;
    Total: number;
}
