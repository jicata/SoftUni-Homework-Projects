import {loginReducer, registerReducer} from './authReducer'
import statsReducer from './statsReducer';
import furnitureReducer from './furnitureReducer'

export default {
    register: registerReducer,
    login: loginReducer,
    stats: statsReducer,
    furniture: furnitureReducer
}
