import { Component, Injector, ViewChild } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  OrganizationUnitServiceProxy,
  OrganizationUnitDto,
  OrganizationUnitDtoPagedResultDto,
  OUListDto
} from '@shared/service-proxies/service-proxies';
import { CreateOrganizationUnitDialogComponent } from './create-organizationunit/create-organizationunit-dialog.component';
import { EditOrganizationUnitDialogComponent } from './edit-organizationunit/edit-organizationunit-dialog.component';
import {MenuItem, PrimeNGConfig, TreeNode} from 'primeng/api';
import {MessageService} from 'primeng/api';

class PagedOrganizationUnitsRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './organizationunits.component.html',
  animations: [appModuleAnimation()],
  providers: [MessageService]
})
@ViewChild('samples')
export class OrganizationUnitsComponent extends PagedListingComponentBase<OUListDto> {
  organizationUnits: Object[];
  keyword = '';
  field: Object;
  files: OUListDto[];
  selectedFile: OUListDto;
  items: MenuItem[];

  constructor(
    injector: Injector,
    private _organizationUnitsService: OrganizationUnitServiceProxy,
    private _modalService: BsModalService,
    private messageService: MessageService,
    private primengConfig: PrimeNGConfig,
  ) {
    super(injector);
  }

  list(
    request: PagedOrganizationUnitsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._organizationUnitsService
      .getFileStructure()
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result) => {
        this.organizationUnits = result;
        this.files = result;
      });

      this.items = [
        {label: 'Edit', icon: 'pi pi-pencil', command: (event) => this.editOrganizationUnit(this.selectedFile)},
        {label: 'Add sub-unit', icon: 'pi pi-plus', command: (event) => this.addSubOrganizationUnit(this.selectedFile)},
        {label: 'Delete', icon: 'pi pi-times', command: (event) => this.delete(this.selectedFile)}
    ];

    this.primengConfig.ripple = true;
  }

  delete(organizationUnit: OUListDto): void {
    abp.message.confirm(
      this.l('OrganizationUnitDeleteWarningMessage', organizationUnit.label),
      undefined,
      (result: boolean) => {
        if (result) {
          this._organizationUnitsService
            .delete(organizationUnit.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createOrganizationUnit(): void {
    this.showCreateOrEditOrganizationUnitDialog();
  }

  // deleteUnit(organizationUnit: OUListDto): void {
  //   this.showCreateOrEditOrganizationUnitDialog(Number(organizationUnit.id));
  // }

  editOrganizationUnit(organizationUnit: OUListDto): void {
    this.showCreateOrEditOrganizationUnitDialog(organizationUnit.id);
  }

  addSubOrganizationUnit(organizationUnit: OUListDto): void {
    this.showAddSubOrganizationUnitDialog(organizationUnit.id);
  }

  showCreateOrEditOrganizationUnitDialog(id?: number): void {
    let createOrEditOrganizationUnitDialog: BsModalRef;
    if (!id) {
      createOrEditOrganizationUnitDialog = this._modalService.show(
        CreateOrganizationUnitDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditOrganizationUnitDialog = this._modalService.show(
        EditOrganizationUnitDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditOrganizationUnitDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  showAddSubOrganizationUnitDialog(id: number): void {
    let createSubganizationUnitDialog: BsModalRef;

    createSubganizationUnitDialog = this._modalService.show(
        CreateOrganizationUnitDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id
          },
        }
      );

      createSubganizationUnitDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

//   viewFile(file: TreeNode) {
//     this.messageService.add({severity: 'info', summary: 'Node Details', detail: file.label});
// }

// unselectFile() {
//     this.selectedFile = null;
// }
}
