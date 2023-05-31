export interface GamesPageResult {
  items: GameItem[]
  pageNumber: number
  totalPages: number
  totalCount: number
  hasPreviousPage: boolean
  hasNextPage: boolean
}

export interface GameItem {
  id: number
  title: string
}
