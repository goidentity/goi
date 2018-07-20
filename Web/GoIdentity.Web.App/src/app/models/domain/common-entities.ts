export class FontIcon {
    public FontIconId: Number
    public IconName: string
    public IconFont: string
}

export class Item {
    Text: string
    Value: number
}

export class GridColumn {
    IsSelected?: boolean
    ColumnName: string
    DisplayTitle: string
    DataType: string
    Format?: string
    ColumnOrder?: number
    IncludeGridSearch?: boolean

    Width?: number
    Desktop?: boolean
    Tab?: boolean
    Mobile?: boolean

    FilterType?: string
}

export class GridDisplayFormat {
    constructor() {
        this.Columns = [];
    }
    GridDisplayFormatId: number

    DataSetId: number
    VoucherTypeId: number

    DirectQuery: string
    ParmsCondition: string
    OrderByCondition: string
    GroupByColumns: string
    ParmDatasetName: string

    JsonFeed: string

    Columns: GridColumn[]
}