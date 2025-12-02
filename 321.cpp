#include <iostream>
#include <string>
using namespace std;

const string STAGE_NAMES[] = {"IF", "ID", "EX", "MEM", "WB"};

int main() {
   
    int I1_stage = 0;  
    int I2_stage = 0; 
    int I3_stage = 0; 

    const int PIPELINE_STAGES = 5;
    int cycle = 0;
    bool done = false;

    bool I1_EX_ready = false; 
    bool I1_WB_ready = false; 
    bool I2_EX_ready = false;
    bool I2_WB_ready = false;

    while (!done) {
        cycle++;
        done = true;
        cout << "Cycle " << cycle << ":\n";

        if (I1_stage < PIPELINE_STAGES) {
            done = false;

            if (I1_stage == 2) {
                I1_EX_ready = true;
            }

            if (I1_stage == 4) { 
                I1_WB_ready = true;
            }

            cout << "  " << STAGE_NAMES[I1_stage] << ": I1 (A=B+C)\n";
            I1_stage++;
        }

        if (I2_stage < PIPELINE_STAGES) {
            done = false;

            if (I2_stage == 2) { 
                if (I1_EX_ready && !I1_WB_ready) {
                    cout << "  EX: I2 (D=A+E) [forwarding from I1.EX]\n";
                    I2_EX_ready = true;
                    I2_stage++;
                }
                else if (I1_WB_ready) {
                    cout << "  EX: I2 (D=A+E) [got A from I1.WB]\n";
                    I2_EX_ready = true;
                    I2_stage++;
                }
                else {
                    cout << "  ID: I2 (stall, waiting for A from I1)\n";
                }
            }
            else {
                cout << "  " << STAGE_NAMES[I2_stage] << ": I2 (D=A+E)\n";
                I2_stage++;

                if (I2_stage == 3) { 
                    I2_EX_ready = true;
                }
                if (I2_stage == 5) { 
                    I2_WB_ready = true;
                }
            }
        }

        if (I3_stage < PIPELINE_STAGES) {
            done = false;

            if (I3_stage == 2) {EX

                if (I2_EX_ready && !I2_WB_ready) {
                    cout << "  EX: I3 (F=D-B) [forwarding from I2.EX]\n";
                    I3_stage++;
                }
                else if (I2_WB_ready) {
                    cout << "  EX: I3 (F=D-B) [got D from I2.WB]\n";
                    I3_stage++;
                }
                else {
                    cout << "  ID: I3 (stall, waiting for D from I2)\n";
                }
            }
            else {
                cout << "  " << STAGE_NAMES[I3_stage] << ": I3 (F=D-B)\n";
                I3_stage++;
            }
        }

        cout << "-----------------\n";
    }

    return 0;
}
