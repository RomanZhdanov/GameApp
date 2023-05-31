import axios from 'axios'
import * as gamesService from './games.service'

const http = axios.create({
  baseURL: import.meta.env.VITE_API_URL
})

export default http

export { gamesService }
