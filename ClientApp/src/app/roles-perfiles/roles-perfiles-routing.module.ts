import { NgModule } from '@angular/core';
import { RolesPerfilesComponent } from './roles-perfiles.component';
import { RolesComponent } from './roles/roles.component';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [
    {
        path: 'roles-perfiles',
        component: RolesPerfilesComponent,
        children: [
            {
                path: 'roles',
                component: RolesComponent,
            },
            {
                path: 'perfiles',
                component: PerfilesComponent
            }
        ]
    }
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class RolesPerfilesRoutingModule{}