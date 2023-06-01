import http from '@/services/'
import type { GamesPageResult } from '@/types/gameTypes'

const API_URL = 'games'

export const search = async (search: string, page: number, pageSize: number) =>
  await http.get<GamesPageResult>(
    API_URL + `/search?search=${search}&page=${page}&pageSize=${pageSize}`
  )

export const getPage = async (page: number, pageSize: number) =>
  await http.get<GamesPageResult>(API_URL + `?page=${page}&pageSize=${pageSize}`)
