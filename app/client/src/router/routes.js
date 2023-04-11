import SignInPage from '../pages/signIn/SignInPage'
import SignUpPage from '../pages/signUp/SignUpPage'
import EventsPage from '../pages/events/EventsPage'
import DirectoryPage from '../pages/directory/DirectoryPage'


/**
 * Маршруты, доступные только авторизованным пользователям
 */
export const privateRoutes = [
    {path: '/events',       title: 'События',       element: EventsPage},
    {path: '/directory',    title: 'Справочник',    element: DirectoryPage}
];

/**
 * Маршруты, доступные неавторизованным пользователям
 */
export const publicRoutes = [
    {path: '/signUp',   title: 'Регистрация',   element: SignUpPage},
    {path: '/signIn',   title: 'Войти',         element: SignInPage}
];