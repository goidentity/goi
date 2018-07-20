export class Enquiry {
    public EnquiryId: number;
    public AcademicYearId: number;
    public EnquiryNumber: string;
    public EnquirySerial: number;
    public FirstName: string;
    public LastName: string;
    public EnquiryDate: Date;
    public IsAdmitted: boolean;
    public LocationId: number;
    public ClassId: number;
    public SpecialisationId: number;
    public StudentTypeId: number;
    public JsonData: string;

    public ClassIds: string;

}

export class vEnquiry {
    public EnquiryId: number;
    public EnquiryNumber: string;
    public FirstName: string;
    public LastName: string;
    public IsAdmitted: boolean;
    public LocationId: number;
    public ClassId: number;
    public Class: string;
    public StudentType: string;
    public Specialisation: string;


    public ClassIds: string;

}

