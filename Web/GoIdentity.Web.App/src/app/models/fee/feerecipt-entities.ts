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
export class vFeeRecipt {
    public FeeReceiptId: number;
    public LocationId: number;
    public ReceiptDate: Date;
    public FeeOrganization: string;
    public ModeOfPayment: string;
    public Amount: number;

}
export class vDcrDepositSummary {
    public RowNumber: number;
    public ReceiptDate: number;
    public ComponentTypeId: number;
    public ComponentTypeTitle: string;
    public OrganizationId: number;
    public OrganizationTitle: string;
    public LocationId: number;
    public Title: string;
    public  ModeOfPaymentId :number;
    public ModeOfPaymentTitle: string;
    public Collected: number;
    public InProcess: number; 
    public Approved: number;
    public Rejected: number; 
    public Deposited: number;
    public Balance: number; 
}