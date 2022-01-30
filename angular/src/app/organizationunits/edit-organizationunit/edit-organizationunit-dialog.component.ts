import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  OrganizationUnitServiceProxy,
  // GetOrganizationUnitForEditOutput,
  OrganizationUnitDto,
  PermissionDto,
  CreateOrganizationUnitDto,
  // FlatPermissionDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-organizationunit-dialog.component.html'
})
export class EditOrganizationUnitDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  organizationUnit = new OrganizationUnitDto();
  id: number;
  // permissions: FlatPermissionDto[];
  // grantedPermissionNames: string[];
  // checkedPermissionsMap: { [key: string]: boolean } = {};

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _organizationUnitService: OrganizationUnitServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._organizationUnitService
      .get(this.id)
      .subscribe((result) => {
        this.organizationUnit = result;
      });
  }

  save(): void {
    this.saving = true;

    // const organizationUnit = new OrganizationUnitDto();
    // organizationUnit.init(this.organizationUnit);
    // organizationUnit.grantedPermissions = this.getCheckedPermissions();

    this._organizationUnitService
      .update(this.organizationUnit)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
