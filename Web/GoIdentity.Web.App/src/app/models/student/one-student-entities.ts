export class Pupil {
    public PupilId: number;
    public EnquiryId: number;
    public AdmissionNumber: string;
    public FirstName: string;
    public LastName: string;
    public MobileNumber: string;
    public UniqueId: string;
    public JsonFeed: string;
}

export class vPupilInfo {
    public PupilId: number;
    public AdmissionNumber: string;
    public Name: string;
    public LocationId: number;
    public ClassId: number;
    public ClassTitle: string;
    public SectionId: number;
    public AcademicPositionStatusId: number;
    public AcademicYearId: number;
    public StudentTypeId: number;
    public IsNewStudent: boolean;
    public ReleaseDate: Date;
    public CurrentStatus: string;
}

export class FeeSummary {
    public DcrDate: Date;
    public ComponentTypeSequenceId: number;
    public ComponentTypeId: number;
    public ComponentType: string;

    public AcademicYearId: number;
    public AcademicYear: string;

    public ComponentId: number;
    public Component: string;

    public ComponentSortId: number;

    public OrganizationId: number;
    public Organization: string;

    public FeeAmount: number;
    public Collected: number;
    public Refunded: number;
    public Concession: number;
    public DueAmount: number;
    public NowPaid: number;

    public AllowCollection: boolean;
}

export class FeeReceiptCheque {

    constructor() {
        this.IFSC = "";
        this.ChequeDate = new Date;
    }

    public FeeReceiptChequeId: number;
    public FeeReceiptId: number;
    public ChequeNo: string;
    public ChequeDate: Date;
    public IFSC: string;
    public BankName: string;
    public BankCode: string;
    public BankBranch: string;
    public BankBranchAddress: string;
    public CardAuthorizationCode: string;
    public CardReferenceNumber: string;
    public ChequeStatusId: number
    public Remarks: string;
}

export class FeeReceiptInput {
    constructor() {
        this.Cheque = new FeeReceiptCheque();
    }

    public ReceiptType: string;
    public PupilId: number;
    public AcademicYearId: number;
    public ComponentTypeSequenceId: number;
    public FeeOrganizationId: number;
    public DcrDate: Date;
    public ModeOfPaymentId: number;
    public Amount: number;
    public ReceiptStatusId: number;
    public Remarks: string;

    public Details: Array<FeeSummary>;
    public Cheque: FeeReceiptCheque;
}
