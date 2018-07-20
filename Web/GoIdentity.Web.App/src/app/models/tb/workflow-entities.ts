import { TreeItem } from 'ngx-treeview';
import { Observable } from 'rxjs';

export class Workflow {
    public WorkflowId: number;
    public Title: string;

    public DataSetId: number;
    public VoucherTypeId: number;

    public RawCondition: string;
    public ConditionJsonFeed: string;
    public JsonFeed: string;
}

export class vWorkflow extends Workflow {
    public DataSet: string;
    public VoucherType: string;
}

//ActivityTypeId = 1-approval,2-notify
export class WorkflowAction {
    constructor() {
        this.StartConstraints = [];
    }

    public WorkflowActionId: number;
    public WorkflowId: number;

    public Title: string;
    public UniqueId: string;
    public ActivityTypeId: number

    public RawCondition: string;
    public ConditionJsonFeed: string;

    public JsonFeed: string;

    public SortId: number;

    public ApprovalSetup: WfApprovalActivitySetup;
    public NotificationSetup: WfNotificationActivitySetup;

    /*not mapped */
    public StartConstraints: WfCondition[];
}

export class WorkflowActivityType {
    public ActivityTypeId: number;
    public Title: string;

    public IsStart: boolean;
    public IsReserved: boolean;
}

export class WfCondition {
    public Field: string;
    public Value: string;
    public Condition: string;
    public Join: string;
}

export class WfApprovalActivity {
    public WfApprovalActivityId: number;
    public DataSetId: number;
    public DataKeyId: number;
    public VoucherId: number;

    public ActivityGuid: string;
    public ApprovalStatusLookupId: number;
    public ApprovalStatusId: number;
    public StatusActionedBy: number;
    public Comments: string;
}

export class WfApprovalActivitySetup {

    constructor() {
        this.ActionGroupsArray = [];

        this.ApprovedActionsArray = [];
        this.ApprovedNotifyArray = [];

        this.RejectedActionsArray = [];
        this.RejectedNotifyArray = [];

        this.PendingActionsArray = [];
        this.PendingNotifyArray = [];
    }

    public WfApprovalActivitySetupId: number;

    public WorkflowId: number;
    public ActivityGuid: string;

    public ActionGroups: string;
    public ActivityLookupId: number;//inprocees,approved,rejected for lookup
    public DefaultActivityLookupValueId?: number;
    public LookupFieldMapping: string;

    public ApprovedActions: string;//approved,rejected,hold-multi select (values populated from lookup)
    public ApprovedNotify: string;//roles from organization-multi select

    public RejectedActions: string;//same 
    public RejectedNotify: string;

    public PendingActions: string;
    public PendingNotify: string;

    public UpdateStatus: boolean;//checkbox
    public UpdateLinks: boolean;
    public UpdateInventory: boolean;
    public UpdateAccounting: boolean;

    /* Not Mapped Items */
    public ActionGroupsArray: number[];

    public ApprovedActionsArray: number[];
    public ApprovedNotifyArray: number[];

    public RejectedActionsArray: number[];
    public RejectedNotifyArray: number[];

    public PendingActionsArray: number[];
    public PendingNotifyArray: number[];
}

export class WfNotificationActivity {
    public WfNotificationActivityId: number;
    public DataSetId: number;
    public DataKeyId: number;
    public VoucherId: number;

    public ActivityGuid: string;

    public Content: string;
    public Link: string;
}

export class WfNotificationActivitySetup {
    public WfNotificationActivitySetupId: number;

    public WorkflowId: number;
    public ActivityGuid: string;
    public NotificationGroups: string;

    public Email: boolean;
    public TextMessage: boolean;
    public Whatsapp: boolean;

    /* Not Mapped Items*/
    public NotificationGroupsArray: number[];
}

export class WorkflowDoc {
    public Wf: Workflow;

    public StartConstraints: WfCondition[];

    public Actions: WorkflowAction[];

    constructor() {
        this.StartConstraints = [];
        this.Actions = [];
    }
}

export class WorkflowTrackLog {
    public WorkflowTrackLogId: number;
    public WorkflowId: number;
    public WorkflowActionId: number;
    public SortId: number;

    public DataSetId: number;
    public DataKeyId: number;
    public VoucherId: number;

    public Parms: string;
    public JsonFeed: string;

    public StartTime: Date;
    public EndTime: Date;

    public IsTerminated: boolean;
    public IsCompleted: boolean;

    public AdditonalData: string;
}

export class vWfApprovalActivityTrack {
    public WorkflowTrackLogId: number;
    public WorkflowId: number;
    public DataSetId: number;
    public DataKeyId: number;
    public VoucherTypeId: number;
    public VoucherId: number;
    public WorkflowAction: string;
    public DefaultActivityLookupValueId: number;
    public ActivityLookupId: number;
    public ActionGroups: string;
    public WfApprovalActivityId: number;
    public ApprovedComments: string;
    public SelectedLookupDetailId: number;
    public Status: string;
    public WorkflowApprovalStatusId: number;
    public EndTime: Date;

 }