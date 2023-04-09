import { SignInPage } from '../pages/signIn/SignInPage'
import { SignUpPage } from '../pages/signUp/SignUpPage'
import { EventsPage } from '../pages/events/EventsPage';


/**
 * Маршруты, доступные только авторизованным пользователям
 */
export const privateRoutes = [
    {path: '/events',   element: EventsPage}
];

/**
 * Маршруты, доступные неавторизованным пользователям
 */
export const publicRoutes = [
    {path: '/signUp',   element: SignUpPage},
    {path: '/signIn',   element: SignInPage}
];