/// <reference path="role-entities.ts" />
import { vMapUserRole } from "./role-entities"

export class ChangePassword {
    public UserId: number;
    public CurrentPassword: string;
    public NewPassword: string;
    public ConfirmNewPassword: string;
}

export class Client {

    public ClientId: number;
    public Title: string;
    public SiteUrl: string;

    public AlternativeSiteUrl: string;

    public IsActive: boolean;

    public ProductLogo: string;
    public FooterLogo: string;

    public ProductName: string;
    public ProductUrl: string;

    public PoweredByName: string;

    public IsGoogleTwoFactorEnabled: boolean;
}

import { TreeItem } from 'ngx-treeview';
import { expand } from "rxjs-compat/operator/expand";

export class Employee {
    public EmployeeId: number;
    public EmployeeNumber: string;
    public FirstName: string;
    public LastName: string;

    public Email: string;
    public MobileNumber: string;

    public UniqueId: string;
    public JsonFeed: string;
}

export class vEmployee {
    public EmployeeId: number;
    public EmployeeNumber: string;
    public FirstName: string;
    public LastName: string;
    public Name: string;

    public Email: string;
    public MobileNumber: string;

    public UniqueId: string;
    public FromDate: Date;
    public LocationId: number;
    public EmployeeLevelId: number;

    public SupervisorId: number;
    public SupervisorEmployeeNumber: string;
    public SupervisorName: string;

    public IsActive: boolean;

}

export class Navigation {
    public NavigationUid: string;
    public NavigationId: number;
    public OrganizationId: number;

    public DataSetId: number;
    public ReportDocumentId: number;
    public DashboardId: number;

    public Title: string;
    //public PageTitle: string;
    public NavigationPath: string;
    public LevelId: number;
    public ParentNavigationId?: number;
    public DocuementPageId?: number;
    public IsReadOnly: boolean;
    public ImagePath: string;
    public SortId: number;

    public hasChildren: boolean;

    public ChildItems: Navigation[];
}

export class NavigationTreeItem implements TreeItem {
    public text: string;
    public value: any;
    public disabled?: boolean;
    public checked?: boolean;
    public collapsed?: boolean;
    public children?: TreeItem[];
}

export class vMapOrganization {
    public MapUserOrganizationId: number
    public UserId: number
    public OrganizationId: number
    public Title: string
}

export class Organization {
    public OrganizationId: number
    public ClientId: number
    public Title: string
    public ShortName: string
    public IsLocked: boolean
    public DatabaseName: string
    public IsActive: boolean
}

export class MapUserOrganization {
    public MapUserOrganizationId: number
    public UserId: number
    public OrganizationId: number
    public IsActive: boolean
}

export class UserProfile {
    public Employee: Employee;
    public MapOrganizations: MapUserOrganization[];
    public MapRoles: vMapUserRole[];
    public AvatarUrl: string;
    public Organizations: Organization[];
    public Navigations: Navigation[];
}


export class MyUserProfile {
    [key: string]: string | number | Date;
    constructor(
        public Id: number,
        public FirstName: string,
        public LastName: string,
        public Gender: string,
        public EmailId: string,
        public PhoneNumber: string,
        public MiddleName?: string,
        public DOB?: Date,
        public PlaceOfBirth?: string,
        public CurrentCity?: string,
        public HomeTown?: string,
        public AadharCard?: string,
        public MartialStatus?: string

    ) { }
}

export class UserPersonnelInfo {
    public UserPersonnelInfoId: number;
    public UserId: number;

    public DoB: Date;
    public Gender: string;
    public PlaceOfBirth: string;
    public CityOfLiving: string;

    public CityOfWork: string;
    public MaritalStatus: string;
    public BirthOfOrigin: string;
    public Nationality: string;
    public Citizenship: string;
    public PRStatus: string;

    public PrimaryIndustryOfWork: string;
    public PrimaryIndustryOfWorkArray: string[];
    public SecondaryIndustryOfWork: string;
    public SecondaryIndustryOfWorkArray: string[];

    public PrimaryIndustryOfBusiness: string;
    public PrimaryIndustryOfBusinessArray: string[];
    public SecondaryIndustryOfBusiness: string;
    public SecondaryIndustryOfBusinessArray: string[];

    public FutureRole: string;

    public FutureIndustryOfWork: string;
    public FutureIndustryOfWorkArray: string[];

    public FutureIndustryOfBusiness: string;
    public FutureIndustryOfBusinessArray: string[];
}

export class UserExperience {
    public UserExperienceId: number;
    public UserId: number;

    public OrganizationName: string;
    public Designation: string;
    public Roles: string;
    public StartDate: Date;
    public EndDate: Date;
    public IsCurrent: boolean;
    public ReasonForChange: string;
}

export class UserEducation {
    public UserEducationId: number;
    public UserId: number;

    public DegreeType: string;
    public Title: string;
    public UniversityOrBoard: string;
    public InstitutionOrBoard: string;
    public YearOfPass: string;
    public Specialization: string;
}

export class BusinessProfile {
    public BusinessProfileId: number;
    public UserId: number;

    public CompanyName: string;
    public YearOfEstablishment: number;
    public ComponySize: string;
    public Role: string;    
}

export class User {
    public UserId: number;

    public UserName: string;
    public Password: string;
    public FirstName: string;
    public MiddleName: string;
    public LastName: string;

    public Email: string;
    public MobileNumber: string;

    public UniqueId: string;
    public JsonFeed: string;

    public IsLocked: boolean;
    public AccountType: number;

    public PersonnelInfo: UserPersonnelInfo;
    public Experience: UserExperience[];
    public Education: UserEducation[];
    public BusinessData: BusinessProfile[];
}