export class ExamSchedule {
    public ExamScheduleId: number;
    public PaperTitle: string;
    public ExamTypeId: number;
    public ClassId: number;
    public MaximunMarks: number;
    public GradeTypeId: number;
    public IsIncludeInTotal: boolean;
    public BaseMark: number;
    public SortingId: number;
    public ShowDetail: boolean;
    public IsGrade: boolean;
    public GradeTitle: string;
    public ExamSchedule: GradeType
}
export class vExamSchedule {
    public ExamScheduleId: number;
    public PaperTitle: string;
    public ExamTypeId: number;
    public Id: number;
    public MaximunMarks: number;
    public BaseMark: number;
    public GradeTitle: string;
}
export class GradeType {
    public GradeTypeId: number;
    public GradeTitle: string;
    public IsValid: boolean;
}