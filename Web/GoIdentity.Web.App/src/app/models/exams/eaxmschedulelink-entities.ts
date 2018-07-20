export class ExamScheduleLink {
    public ExamScheduleLinkId: number;
    public ExamScheduleId: number;
    public ExamSchedulePaperId: number;
    public BaseMarks: number;
    public PaperTitle: string;
    public ExamScheduleLink: ExamSchedule
}
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
}
export class vExamScheduleLink {
    public ExamType: string;
    public PaperTitle: string;
    public MaximunMarks: number;
    public BaseMarks: number;
    public ExamTypeId: number;
    public ClassId: number;
    public ExamScheduleLinkId: number;
    public ExamScheduleId: number;
    public ExamSchedulePaperId: number;
    public PaperTypeTitle: string;
    public Title: string;
}
