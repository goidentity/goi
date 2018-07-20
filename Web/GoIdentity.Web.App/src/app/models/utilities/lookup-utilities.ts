import { LookUp, LookUpDetail } from "../domain/lookup-entities";
import { DocumentDataSetDetail } from "../tb/tb-entities";
import { SalaryComponent } from '../oneemployee/salarycomponent.entities';


export class LookupUtilities {
    public static getLookupDetailId(lookupDetails: Array<LookUpDetail>, lookupValue: string): number {
        return lookupDetails.filter(ld => ld.Value === lookupValue)[0].LookupDetailId;
    }
}

export class FieldEntities {
    public static getControlFullName(field: DocumentDataSetDetail, addPrefixChar: boolean): string {
        return (addPrefixChar ? "@" : "") + "[" + field.Scope + ":" + field.FieldName + "]";
    }

    public static getCacheKey(field: DocumentDataSetDetail, parms: string): string {
        return field.SourceTypeId.toString() + ":" + field.Source + ":" +
            ((parms == undefined || parms == null) ? "" : parms);
    }
}

export class SalaryComponentEntitiesForAssignSalary {
    public static getControlFullFormula(field: SalaryComponent): string {
        return "@" + "[" + "Basic" + "]";
    }
}
export class SalaryComponentEntities {
    public static getControlFullFormula(field: SalaryComponent, addPrefixChar: boolean): string {
        return (addPrefixChar ? "@" : "") + "[" + field.Title + "]";
    }
}