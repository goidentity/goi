export class DcrDeposit {
    public DcrDepositId: number;
    public ReceiptDate: Date;
    public LocationId: number;
    public ComponentTypeId: number;
    public FeeOrganizationId: number;
    public ModeOfPaymentId: number;
    public BankAccountDetailId: number;
    public CounterfoilNo: string;
    public Amount: number;
    public Remarks: string;
    public DepositedDate: Date;
    public ApprovedDateTime: Date;
    public ApprovedBy: number;
    public RecordCreatedBy: string;
    public RecordCreatedDateTime: Date;
    public RecordModifiedBy: number;
    public RecordModifiedDateTime: Date;
    public Bank: string;
    public DcrDeposit: BankAccountDetails;

}
export class vDcrDeposit {
    public DcrDepositId: number;
    public BankAccDetailsId: number;
    public FeeOrganizationId: number;
    public ModeOfPaymentId: number;
    public LocationId: number;
    public CounterfoilNo: string;
    public DepositedDate: Date;
    public Amount: number;
    public Bank: string;

}
export class vDcrDepositSummary {
    public RowNumber: number;
    public ReceiptDate: number;
    public ComponentTypeId: number;
    public ComponentTypeTitle: string;
    public FeeOrganizationId: number;
    public OrganizationTitle: string;
    public LocationId: number;
    public Title: string;
    public ModeOfPaymentId: number;
    public ModeOfPaymentTitle: string;
    public Collected: number;
    public InProcess: number;
    public Approved: number;
    public Rejected: number;
    public Deposited: number;
    public Balance: number;
}
export class BankAccountDetails {
    public BankAccountDetailId: number;
    public AccountNumber: number;
    public Bank: string;
    public IFSC: string;
    public SwiftCode: string;
}