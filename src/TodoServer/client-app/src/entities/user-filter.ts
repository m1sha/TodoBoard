export class UserFilter {
  
  page: number
  count: number
  sort: number
  search: string
  
  constructor () {
    this.page = 0
    this.count = 50
    this.sort = 1
    this.search = ""
  }

}