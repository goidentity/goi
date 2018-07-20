import { TreeItem } from 'ngx-treeview';
import { Observable } from 'rxjs';

export class LinkSetup {
    LinkSetupId: number
    LinkTitle: string
    BaseDataSetId: number
    LinkDataSetId: number
    BaseField: string
    KeyField: string

    IsEditBase: boolean
    IsExceedBase: boolean
    IsMandotry: boolean
    IsLinkFifo: boolean
    IsLinkUpdate: boolean

    ParmDataSetId: number
    Query: string
}

export class vLinkSetup extends LinkSetup {    
    BaseDataSet: string
    LinkDataSet: string
}

export class LinkData {
    LinkDataId: number
    DocNo: string
    DocDate: Date
    DueDate: Date

    DataSetId: number
    DataSetKeyId: number
    DataSetDetailUniqueId: string

    LinkId: number

    AccountHeadId: number
    CustomerId: number
    ProductId: number

    Quantity: number
    Rate: number
    Amount: number

    LocationId: number
    BatchNo: string
    MfgDate: Date
    ExpiryDate: Date

    ReferenceId: number
    JsonFeed: number
}

export class vLinkAggregateData extends LinkData {
    AdjustedQuantity: number
    AdjustedAmount: number

    PendingQuantity: number
    PendingAmount: number

    Customer: string
    Product: string
    Location: string
}