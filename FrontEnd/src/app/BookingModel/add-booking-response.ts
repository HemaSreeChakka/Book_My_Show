export interface AddBookingResponse {
ticketId:number,
    transactionMode: string;
transactionStatus:string;
    seats:number;
    totalCost:number;
    bookingDate: Date;
}
