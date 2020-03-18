import { User } from './user'

export class TodoItem {
  id: string
  title: string
  message: string
  status: number
  type: number
  createByUser: User
  assignToUser: User

  constructor(){
    this.id = ""
    this.title = ""
    this.message = ""
    this.status = 0
    this.type = 0
    this.createByUser = new User()
    this.assignToUser =  new User()
  }
}