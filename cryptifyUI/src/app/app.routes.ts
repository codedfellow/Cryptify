import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', loadComponent: () => import('./components/home/home').then(m => m.Home) },
    { path: 'base64', loadComponent: () => import('./components/base64/base64').then(m => m.Base64) },
    {path: '**', loadComponent: () => import('./components/not-found/not-found').then(m => m.NotFound)}
];
