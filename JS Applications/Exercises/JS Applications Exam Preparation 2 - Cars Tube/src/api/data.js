import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllListings(){
    return api.get('/data/cars?sortBy=_createdOn%20desc');
}

export async function createListing(data){
    return api.post('/data/cars', data);
}

export async function getListingById(id){
    return api.get(`/data/cars/${id}`);
}

export async function deleteListing(id){
    return api.del(`/data/cars/${id}`);
}

export async function editListing(id, data){
    return api.put(`/data/cars/${id}`, data);
}
export async function getCarsById(userId){
    return api.get(`/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function cardByYear(year){
    return api.get(`/data/cars?where=year%3D${year}`);
}