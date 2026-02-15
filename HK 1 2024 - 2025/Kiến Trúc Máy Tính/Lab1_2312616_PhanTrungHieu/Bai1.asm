.model small
.stack 100h
.data 
    a db 13,10,'Hello World! $'  
    b db 13,10,'Hello solar system! $'
    c db 13,10,'Hello universe! $'
.code  
main proc               
    mov ax,@data 
    mov ds, ax
    mov ah, 9
    lea dx,a 
    int 21h 
    
    mov ax,@data 
    mov ds, ax
    mov ah, 9
    lea dx,b 
    int 21h 
    
    mov ax,@data 
    mov ds, ax
    mov ah, 9
    lea dx,c 
    int 21h 
           
    mov AX, 4ch
    int 21h  
main endp
end main