import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appRole]',
  standalone: true
})
export class RoleDirective {

  private userRole: string = '';

  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef
  ) {}

  @Input() set appRole(allowedRoles: string | string[]) {
    this.updateView(allowedRoles);
  }

  @Input() set appRoleUser(role: string) {
    this.userRole = role;
  }

  private updateView(allowedRoles: string | string[]) {
    const roles = Array.isArray(allowedRoles) ? allowedRoles : [allowedRoles];

    this.viewContainer.clear();

    if (roles.includes(this.userRole)) {
      this.viewContainer.createEmbeddedView(this.templateRef);
    }
  }
}