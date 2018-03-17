export interface ICryptoUtils {
    encrypt(type: string, text: string, key: string): string;
    decrypt(type: string, ciphertext: string, key: string): string;
}