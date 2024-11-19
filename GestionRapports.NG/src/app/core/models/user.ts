export interface User {
    id_User?: number;
    firstName?: string;
    lastName?: string;
    email: string;
    role?: string;
    isAdmin?: boolean;
    password: string
}
//Be carefull! almost all the arguments are nullable for testing