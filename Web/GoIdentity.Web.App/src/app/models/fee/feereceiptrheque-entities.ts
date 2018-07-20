export class FeeReceiptCheque {
    public FeeReceiptChequeId: number;
    public FeeReceiptId: number;
    public ChequeNo: string;
    public ChequeDate: Date;
    public BankName: string;
    public BankBranch: string;
    public BankBranchAddress: string;
    public CardAuthorizationCode: string;
    public CardReferenceNumber: string;
    public ChequeStatusId: number;
    public Remarks: string;
    public RecordCreatedBy: number;
    public RecordCreatedDateTime: Date;
    public RecordModifedBy: number;
    public RecordModifiedDateTime: Date;
    public LocationId: number;
    public PrintReceiptNumber: number;
    public Amount: number;
    public FeeReceiptCheque: FeeRecipt;

}

export class FeeRecipt {
    public FeeReceiptId: number;
    public PupilId: number;
    public ReceiptDate: Date;
    public CollectionDate: Date;
    public ModeOfPaymentId: number;
    public FeeReceiptSerialNumber: number;
    public ComponentTypeId: number;
    public AcademicYearId: number;
    public ReceiptStatusId: number;
    public ClassCategoryId: number;
    public LocationId: number;
    public StudentTypeId: number;
    public StudentTypeCategoryId: number;
    public FeeOrganizationId: number;
    public PaidLocationId: number;
    public Amount: number;
    public Remarks: string;
    public NoOfPrintOuts: number;
    public UniqueId: number;
    public RecordCreatedBy: number;
    public RecordCreatedDateTime: Date;
    public RecordModifiedBy: number;
    public RecordModifiedDateTime: Date;
    public ManualReceiptNumber: string;
    public PrintReceiptNumber: string;
    public IsDetailed: boolean;

}
export class vFeeReceiptCheque {
    public FeeReceiptChequeId: number;
    public FeeReceiptId: number;
    public LocationId: number;
    public ReceiptDate: Date;
    public ChequeNo: string;
    public PrintReceiptNumber: number;
    public Amount: number;
    public FeeReceiptCheque: FeeRecipt;

}