import { Injectable, ErrorHandler } from '@angular/core';
import { ToasterService, ToasterConfig, BodyOutputType } from 'angular2-toaster/angular2-toaster';

@Injectable()
export class CustomErrorHandler implements ErrorHandler {

    handleError(error: any) {
        // your custom error handling logic
        console.log(error);
        //this.showToasterMessage('error', "Error", error);
    }

    private showToasterMessage(type: string, caption: string, message: string) {
        var toasterService: ToasterService = new ToasterService();
        toasterService.pop(type, caption, message);
    }

    public toasterconfig: ToasterConfig = new ToasterConfig({
        tapToDismiss: true,
        timeout: 5000,
        bodyOutputType: BodyOutputType.TrustedHtml
    });

    constructor() { }
    
}
