export class ExamType {
    public ExamTypeId: number;
    public Title: string;
    public SortingId: number;
    public AcademicYearId: number;
    public GradeTypeId: number;
    public ExamCategoryId: number;
    public PrintTemplateId: number;
    public Id: number;
    public ClassId: number;

    public ClassIds: string;
    public LocationIds: string;
}

export class vExamType {
    public ExamTypeId: number
    public AcademicYearId: number
    public Title: string;
    public SortingId: number;
    public GradeTitle: string;
    public ExamCategoryTitle: string;
 
}


export class MapExamTypeAndLocation {
    public MapExamTypeAndLocationId: number;
    public ExamTypeId: number;
    public Id: number;
}

export class MapExamTypeAndClassCategory {
    public MapExamTypeAndClassCategoryId: number;
    public ExamTypeId: number;
    public ClassId: number;
}


