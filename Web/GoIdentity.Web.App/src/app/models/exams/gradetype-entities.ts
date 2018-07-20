export class GradeType {
    public GradeTypeId: number;
    public GradeTitle: string;
    public IsValid: boolean;
}

export class GradeTypeDetail {
    public GradeTypeDetailId: number;
    public GradeTypeId: number;
    public FromValue: number;
    public ToValue: number;
    public Grade: string;
    public Points: number;
    public IsPassed: boolean;
}
