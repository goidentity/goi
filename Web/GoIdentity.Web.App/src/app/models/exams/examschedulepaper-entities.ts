export class ExamSchedulePaper {
    public ExamSchedulePaperId: number;
    public ExamScheduleId: number;
    public ExamDate: Date;
    public SubjectId: number;
    public AlternateSubjectId: number;
    public PaperTypeId: number;
    public IsIndependentPassRequired: boolean;
    public MaximunMarks: number;
    public BaseMarks: number;
    public GradeTypeId: number;
    public PaperId: number;
    public IncludedInTotal: boolean;
    public Title: string;
    public PaperTypeTitle: string;
    public ExamSchedulePaper: Subject;
    public ExamSchedulePaper1: PaperType;
}
export class vExamSchedulePaper {
    public ExamSchedulePaperId: number;
    public ExamScheduleId: number;
    public ExamDate: Date;
    public SubjectId: number;
    public PaperTypeId: number;
    public MaximunMarks: number;
    public BaseMarks: number;
    public Title: string;
    public PaperTypeTitle: string;

}
export class Subject {
    public SubjectId: number;
    public Title: string;
    public Code: string;
    public IsActive: boolean;
}
export class PaperType {
    public PaperTypeId: number;
    public PaperTypeTitle: string;
    public ShortCode: string;
    public SortId: number;
}
