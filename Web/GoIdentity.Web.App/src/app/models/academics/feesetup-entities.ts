export class vFeeSetup {
    public FeeSetupId: number
    public AcademicYearId: number
    public LocationId: number
    public FeeComponentId: number
    public ClassId: number
    public SpecialisationId: number
    public SemesterId: number
    public StudentTypeId: number
    public FeeOrganizationId: number
    public NewPupilFee: number
    public ExistingPupilFee: number
    public DueDate: Date
    public FeeComponent: string
    public Class: string
    public Specialisation: string
    public Semester: string
    public StudentType: string
    public FeeOrganization: string
}

export class FeeSetup {
    public FeeSetupId: number
    public AcademicYearId: number
    public FeeComponentId: number
    public LocationId: number
    public ClassId: number
    public SpecialisationId: number
    public SemesterId: number
    public StudentTypeId: number
    public FeeOrganizationId: number
    public NewPupilFee: number
    public ExistingPupilFee: number
    public DueDate: Date
    public ParentId: number
}





