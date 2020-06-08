import { NgModule } from '@angular/core';
import { AdministrarComponent } from './administrar.component';
import { RolesComponent } from './roles/roles.component';
import { PerfilesComponent } from './perfiles/perfiles.component';
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [
    {
        path: 'administrar',
        component: AdministrarComponent,
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
export class AdministrarRoutingModule{}
