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
  OrganizationUnitDto,
  PermissionDto,
  CreateOrganizationUnitDto,
  OrganizationUnitDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-organizationunit-dialog.component.html'
})
export class CreateOrganizationUnitDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  organizationUnit: OrganizationUnitDto =  new OrganizationUnitDto();
  id: number;
  // organizationUnits: OrganizationUnitDto[] = [];
  // organizationUnitMap: { [key: string]: string } = {};
  // defaultPermissionCheckedStatus = true;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _organizationUnitService: OrganizationUnitServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.organizationUnit.parentId = this.id;
    // this._organizationUnitService
    //   .getAll(null, null, 10)
    //   .subscribe((result: OrganizationUnitDtoPagedResultDto) => {
    //     this.organizationUnits = result.items;
    //     // this.setInitialPermissionsStatus();
    //   });
  }

  // setInitialPermissionsStatus(): void {
  //   _.map(this.organizationUnits, (item) => {
  //     this.organizationUnitMap[item.name] = this.isPermissionChecked(
  //       item.name
  //     );
  //   });
  // }

  // isPermissionChecked(permissionName: string): boolean {
  //   // just return default permission checked status
  //   // it's better to use a setting
  //   return this.defaultPermissionCheckedStatus;
  // }

  // onPermissionChange(permission: PermissionDto, $event) {
  //   this.checkedPermissionsMap[permission.name] = $event.target.checked;
  // }

  // getCheckedPermissions(): string[] {
  //   const permissions: string[] = [];
  //   _.forEach(this.checkedPermissionsMap, function (value, key) {
  //     if (value) {
  //       permissions.push(key);
  //     }
  //   });
  //   return permissions;
  // }

  save(): void {
    this.saving = true;
    const organizationUnit = new CreateOrganizationUnitDto();
    organizationUnit.init(this.organizationUnit);
    // organizationUnit.grantedPermissions = this.getCheckedPermissions();

    this._organizationUnitService
      .createOU(organizationUnit)
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
