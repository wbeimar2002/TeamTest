import axios from 'axios'

export const getCategories = () => {
    const COMMON_ORDER_API_ENDPOINT = "https://localhost:44318/Categories";
    return axios.get(COMMON_ORDER_API_ENDPOINT, { crossdomain: true })
        .then(response => {
            return response.data;
        }).catch(error => {
            throw error;
        });
};
