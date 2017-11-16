import { AJAX_BEGIN, AJAX_ERROR, FETCH_PAGE_SUCCESS, FETCH_SEARCH_SUCCESS, FETCH_DETAILS_SUCCESS } from "./actionTypes"
import { fetchDetails, fetchPage, fetchSearchPage } from '../api/remote'


function fetchSuccess(data) {
    return {
        type: FETCH_PAGE_SUCCESS,
        data
    }
}


export function fetchDetailsAction(furnitureId) {
    return async (dispatch) => {
        dispatch({ type: AJAX_BEGIN });
        try {
            const data = await fetchDetails(furnitureId);
            dispatch(fetchSuccess(data));
        } catch (err) {
            dispatch({ type: AJAX_ERROR, err })
        }
    }
}


export function fetchPageAction(page) {
    return async (dispatch) => {
        dispatch({ type: AJAX_BEGIN });
        try {
            const data = await fetchPage(page);
            dispatch(fetchSuccess(data));
        } catch (err) {
            dispatch({ type: AJAX_ERROR, err })
        }

    }
}

export function fetchSearchAction(query, page) {
    return async (dispatch) => {
        dispatch({ type: AJAX_BEGIN });
        try {
            const data = await fetchSearchPage(query, page);
            dispatch(fetchSuccess(data));
        } catch (err) {
            dispatch({ type: AJAX_ERROR, err })
        }

    }
}



