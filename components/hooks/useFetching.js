import { useState } from "react";


/**
 * Хук для обработки данных (крутилка при загрузке и обработчик ошибок)
 * @param {*} callback - функция, во время выполнения которой будет показываться "крутилка" и ловиться ошибки
 * @returns {*} [fetching, isLoading, error]
 */
const useFetching = (callback) => {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('')

    const fetching = async (...args) => {
        try {
            setIsLoading(true)
            await callback(...args)
        } catch (e) {
            setError(e.message)
        } finally {
            setIsLoading(false)
        }
    }

    return [fetching, isLoading, error]
}


export default useFetching