;-------------------------------------------------------------------------------
; MSP430 Assembler Code Template for use with TI Code Composer Studio
;
;
;-------------------------------------------------------------------------------
            .cdecls C,LIST,"msp430.h"       ; Include device header file
            
;-------------------------------------------------------------------------------
            .def    RESET                   ; Export program entry-point to
                                            ; make it known to linker.
;-------------------------------------------------------------------------------
            .text                           ; Assemble into program memory.
            .retain                         ; Override ELF conditional linking
                                            ; and retain current section.
            .retainrefs                     ; And retain any sections that have
                                            ; references to current section.

;-------------------------------------------------------------------------------
RESET       mov.w   #__STACK_END,SP         ; Initialize stackpointer
StopWDT     mov.w   #WDTPW|WDTHOLD,&WDTCTL  ; Stop watchdog timer


;-------------------------------------------------------------------------------
; Main loop here
;-------------------------------------------------------------------------------
init:
			CLR.w	P2OUT
			bis.b	#BIT0, &P2DIR			; Set P2 as output
			bic.b	#BIT2, &P1DIR			; Set BIT2 of P1 as an input
			bis.b	#BIT2, &P1SEL0			; Set P1.2 as analog input
			bis.b	#BIT2, &P1SEL1
			bic.w	#0001h, &PM5CTL0

			mov.w   #0210h, &ADCCTL0
			mov.w   #0220h, &ADCCTL1
			mov.w   #0020h, &ADCCTL2
			mov.w   #0002h, &ADCMCTL0

;---------Timer Block Setup
			bis.w	#TBCLR, &TB0CTL			; Set clear bit in control register
			bis.w	#TBSSEL__ACLK, &TB0CTL		; Select ACLK as source
			bis.w   #CNTL__12, &TB0CTL
			bis.w	#ID__8, &TB0CTL
			bis.w	#MC__CONTINUOUS, &TB0CTL	; Select continuous mode counting

                                            
convert:
			mov.w   #0213, &ADCCTL0			; Start ADC

here:			bit.w	#BIT0, &ADCIFG			; Check for ADC conversion to be made
			jz	here
			mov.w	ADCMEM0, &TB0R			; Once converted, timer is set with the value
			jmp 	inner_delay			; Jump to delay
			nop

inner_delay:
			cmp.w	#0000h,TB0R
			jnz inner_delay				; Program looping for overflow from pot value to 0000h
			xor.b	#BIT0, &P2OUT			; Toggle LED
			jmp	convert

;-------------------------------------------------------------------------------
; Stack Pointer definition
;-------------------------------------------------------------------------------
            .global __STACK_END
            .sect   .stack
            
;-------------------------------------------------------------------------------
; Interrupt Vectors
;-------------------------------------------------------------------------------
            .sect   ".reset"                ; MSP430 RESET Vector
            .short  RESET
            
