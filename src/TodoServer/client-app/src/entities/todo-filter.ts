export class TodoFilter {
  
  page: number
  count: number
  sort: number
  search: string
  
  constructor () {
    this.page = 1
    this.count = 50
    this.sort = 1
    this.search = ""
  }

}