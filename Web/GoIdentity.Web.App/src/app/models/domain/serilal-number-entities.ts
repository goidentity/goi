export class ProjectedSerialNumber
{
    SerialNumberId: string;
    IgnorePrefixSuffix: boolean;
    ProjectedNumber: string;
    Prefix: string;
    Suffix: string;
}

export class SerialNumber {
    public SerialNumberId: number;
    public VoucherTypeId: number;
    public DataSetId: number;
    public OtherSource: string;
    public FieldName: string;
    public Prefix: string;
    public Suffix: string;
    public IgnorePrefixSuffix: boolean;

    public PadLeftSize: string;
    public TrackNumber: number;
    public IsActive: boolean = true;
}

export class vSerialNumber extends SerialNumber {
    public Voucher: string;
    public DataSet: string;    
}

export class SerialNumberTracker {
    public SerialNumberTrackerId: number;
    public SerialNumberId: number;
    public Prefix: string;
    public Suffix: string;
    public TrackNumber: number;
    public IsActive: boolean;
}