import SignInPage from '../pages/signIn/SignInPage'
import SignUpPage from '../pages/signUp/SignUpPage'
import EventsPage from '../pages/events/EventsPage'
import DirectoryPage  from '../pages/directory/DirectoryPage'



/**
 * Маршруты, доступные только авторизованным пользователям
 */
export const privateRoutes = [
    {path: '/events',   element: EventsPage},
    {path: '/directory', element: DirectoryPage}
];

/**
 * Маршруты, доступные неавторизованным пользователям
 */
export const publicRoutes = [
    {path: '/signUp',   element: SignUpPage},
    {path: '/signIn',   element: SignInPage}
];