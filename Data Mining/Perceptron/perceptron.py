# -*- coding: utf-8 -*-
#KostasV-2018
import numpy as np
import math
import re
import sys

#The libraries below are used only in the visualisation part.
import matplotlib.cm as cm
import pandas as pd
import matplotlib.pyplot as plt
from sklearn.decomposition import PCA as sklearnPCA
from sklearn.preprocessing import MinMaxScaler
 

class perceptron:
      
    def __init__(self, size, multi):

        self.weights = np.array([np.random.randn(size)])
        self.bias = 0
        self.weighth=np.array([]).reshape(0,4)
        self.missclass = 0
        self.multi = multi
         
    def update(self, x, y, coeff):
        self.a=np.dot(self.weights,x.T)+self.bias
        if (y*self.a <= 0):
            self.weighth = np.append(self.weighth,self.weights,axis=0)
            #print(self.weights)
            self.weights += y*x - coeff*self.weights
            self.weights = np.around(self.weights, decimals=5)
            self.missclass = self.missclass+1
            self.bias+=y;
             
    def test(self, x):
        a = np.dot(self.weights, x.T)+self.bias
        #In multiclass return the value
        if (self.multi==0):           
            a[a>0]=1
            a[a<0]=-1
        return a;
         
 
 
def main():
    #A menu for the user
    print('Please provide input about the classes:\n')
    print('1:Compare class1-class2\n')
    print('2:Compare class2-class3\n')
    print('3:Compare class1-class3\n')
    print('4:Correlation check\n')
    print('5:Multiclass\n')
    print('6:Visualise the data\n')
    defclass=input('Input:')
    print(defclass)
    #call functions
    if(defclass=='1'):
        single_class(1,2)
    elif(defclass=='2'):
        single_class(2,3)
    elif(defclass=='3'):
        single_class(1,3)
    elif(defclass=='4'):
        correlationCoeff()
    elif(defclass=='5'):
        multi_class()
    elif(defclass=='6'):
        viz()
    else:
        print('Please provide a valid input from 1 till 6')
        sys.exit()       
def single_class(class1,class2):
    #create a conversion "function" to remove the "class-" from the last column
    #Because it is an object needs decoding to a string
    convertfunc = lambda x: float(re.sub("[^0-9]","",x.decode('utf-8')))
     
    #Import datasets as numpy arrays
    #use the convertfunc to have numbers on the last column
    train_data = np.genfromtxt('train.data',delimiter=',',converters={4: convertfunc})
    test_data = np.genfromtxt('test.data', delimiter=',', converters={4: convertfunc})
    visTest = []
    visTrain = []
    for x in range(0,10):
        #for two classes create the training inputs and the testing inputs arrays
        tr_inputs = train_data[np.where(train_data[:,4] == class1)].copy()
        tr_inputs = np.append(tr_inputs,train_data[np.where(train_data[:,4] == class2)].copy(),axis=0)
        tr_inputs[:,4]=np.where(tr_inputs[:,4]!=class1,-1,1)#change the class number into 1 and -1
         
        te_inputs = test_data[np.where(test_data[:,4] == class1)].copy()
        te_inputs = np.append(te_inputs,test_data[np.where(test_data[:,4] == class2)].copy(),axis=0)
        te_inputs[:,4] = np.where(te_inputs[:,4]!=class1,-1,1)
        size=tr_inputs.shape[1]#return the columns which is the number of dimensions
         
        
        #shuffle the order of the training data
        np.random.shuffle(tr_inputs)
        tr_features=tr_inputs[:,0:(size-1)]
        tr_class=tr_inputs[:,(size-1):size]
        #create perceptron
        #call with 0 as a parameter for binary classification
         
        #using a seed to re-create the results
        
        #####CHANGE THE SEED HERE#####
        ## for example x*10
        np.random.seed(x)
        #####
        perc1 = perceptron(size-1,0)
        for it in range(0,20):
            for it2 in range(0,tr_inputs.shape[0]):
                perc1.update(tr_features[it2:(it2+1),:],tr_class[it2:(it2+1),:],0)
        print('Training accuracy of class',class1,'and class',class2,':',(1-(perc1.missclass/((it+1)*(it2+1))))*100, '%')
        visTrain.append((1-(perc1.missclass/((it+1)*(it2+1))))*100)
                 
        #test data 
        te_features = te_inputs[:,0:(size-1)]
        te_class = te_inputs[:,(size-1):size]
        results=perc1.test(te_features[:,:]).T
        error=results==te_class
        visTest.append(((error==True).sum()/error.size)*100)
        print('Test accuracy',((error==True).sum()/error.size)*100, '%')
    plt.plot(visTest,label="Test") 
    plt.plot(visTrain,label="Train") 
    plt.xlabel('Run')
    plt.ylabel('Accuray Percentage(%)')
    plt.ylim(0,110) 
    plt.legend() 
    plt.show()
     
     
 
def multi_class():
    #create a conversion "function" to remove the "class-"from the last column
    #Because it is an object needs decoding to a string
    convertfunc = lambda x: float(re.sub("[^0-9]","",x.decode('utf-8')))
    #Import datasets as numpy arrays
    #use the convertfunc to have numbers on the last column
    train_data = np.genfromtxt('train.data',delimiter=',',converters={4: convertfunc})
    test_data = np.genfromtxt('test.data', delimiter=',', converters={4: convertfunc})
         
     
    #coefficient for regularization
    coef=[0,0.01,0.1,1]
    
    #Loop for different coefficients
    for x in range(0,4):
        print('For coefficient',coef[x])
        #Create as many perceptrons as the classes are
        objlist=[]
        for i in range(1, 4):
            #In order to compare the results with different regularisation coeffs,
            #we need the same "random situation every time" 
            
            #####CHANGE THE SEED HERE#####
            ## for example i*10
            np.random.seed(i)
            ####
            #for the current class create the training inputs and the testing inputs arrays
            tr_inputs = train_data.copy()
            tr_inputs[:,4]=np.where(tr_inputs[:,4]!=i,-1,1)
         
            te_inputs = test_data.copy()
            #In this case a change won't be made in order to evaluate the results later
            #return the column which is the number of dimensions
            size=tr_inputs.shape[1]
         
            #shuffle the order of the training data
            np.random.shuffle(tr_inputs)
            tr_features=tr_inputs[:,0:(size-1)]
            tr_class=tr_inputs[:,(size-1):size]
            
            #call with 0 as a parameter for binary classification
            objlist.append(perceptron(size-1,1))
            for it in range(0,20):
                for it2 in range(0,tr_inputs.shape[0]):
                    objlist[i-1].update(tr_features[it2:(it2+1),:],tr_class[it2:(it2+1),:],coef[x])
            print('Training accuracy of class',i,':',(1-objlist[i-1].missclass/((it+1)*(it2+1)))*100, '%')
         
         
        #test data 
        te_features = te_inputs[:,0:(size-1)]
        te_class = te_inputs[:,(size-1):size]
        results = np.empty((0,1))
        res1=objlist[0].test(te_features[:,:]).T
        res2=objlist[1].test(te_features[:,:]).T
        res3=objlist[2].test(te_features[:,:]).T
        #This part is hardcoded for 3 classes
        for y in range(0,res1.shape[0]):
            maxv=max(res1[y],res2[y],res3[y])
            if(maxv==res1[y]):
                results = np.append(results,[[1]], axis=0)
            elif(maxv==res2[y]):
                results =  np.append(results,[[2]], axis=0)
            elif(maxv==res3[y]):
                results =  np.append(results,[[3]], axis=0)
        error1=results[0:10,0:1]==te_class[0:10,0:1]
        error2=results[10:20,0:1]==te_class[10:20,0:1]
        error3=results[20:30,0:1]==te_class[20:30,0:1]
        perc = np.empty((0,1))
        perc=np.append(perc,[[((error1==True).sum()/error1.size)*100]],axis=0)
        perc=np.append(perc,[[((error2==True).sum()/error2.size)*100]],axis=0)
        perc=np.append(perc,[[((error3==True).sum()/error3.size)*100]],axis=0)
        print('Test accuracy for class 1',perc[0],'%')
        print('Test accuracy for class 2',perc[1],'%')  
        print('Test accuracy for class 3',perc[2],'%')
         
         
        
    return objlist
#Function that visualises the correlation matrix
def correlationCoeff():
    convertfunc = lambda x: float(re.sub("[^0-9]","",x.decode('utf-8')))
    train_data = np.genfromtxt('train.data',delimiter=',',converters={4: convertfunc})
    #Check only class1 and class2
    y1 =np.corrcoef(train_data[0:80,0:6],rowvar=False)
    fig = plt.figure()
    ax1 = fig.add_subplot(111)
    cmap = cm.get_cmap('jet', 60)
    cax = ax1.imshow(y1, cmap=cmap)
    ax1.grid(True)
    plt.title('Feature Correlation')
    labels=["NONE","First","Second","Third","Fourth","Class"]
    ax1.set_xticklabels(labels,fontsize=6)
    ax1.set_yticklabels(labels,fontsize=6)
    fig.colorbar(cax, ticks=[-.40,-.20,0,.20,.40,.60,.80,1])
    plt.show()
    
#Scatter plot visualisation   
def viz():
     
    dataset = pd.read_csv('train.data',names=['first','second','third','fourth','Class'])
    classes = dataset['Class']
    #First plot
    plt.subplot(4, 3, 1)     
    plt.scatter(dataset[classes=='class-1']['first'], dataset[classes=='class-1']['second'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['first'], dataset[classes=='class-2']['second'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['first'], dataset[classes=='class-3']['second'], label='Class 3', c='lightgreen')
     
    plt.plot
    plt.legend()
    plt.xlabel('First')
    plt.ylabel('Second')
    #Second plot
    plt.subplot(4, 3, 2)     
    plt.scatter(dataset[classes=='class-1']['first'], dataset[classes=='class-1']['third'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['first'], dataset[classes=='class-2']['third'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['first'], dataset[classes=='class-3']['third'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('First')
    plt.ylabel('Third')
    #Third plot
    plt.subplot(4, 3, 3)     
    plt.scatter(dataset[classes=='class-1']['first'], dataset[classes=='class-1']['fourth'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['first'], dataset[classes=='class-2']['fourth'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['first'], dataset[classes=='class-3']['fourth'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('First')
    plt.ylabel('Fourth')
    #Fourth plot
    plt.subplot(4, 3, 4)     
    plt.scatter(dataset[classes=='class-1']['second'], dataset[classes=='class-1']['third'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['second'], dataset[classes=='class-2']['third'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['second'], dataset[classes=='class-3']['third'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Second')
    plt.ylabel('Third')
    #Fifth plot
    plt.subplot(4, 3, 5)     
    plt.scatter(dataset[classes=='class-1']['second'], dataset[classes=='class-1']['fourth'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['second'], dataset[classes=='class-2']['fourth'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['second'], dataset[classes=='class-3']['fourth'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Second')
    plt.ylabel('Fourth')
    #Sixth plot
    plt.subplot(4, 3, 6)     
    plt.scatter(dataset[classes=='class-1']['third'], dataset[classes=='class-1']['fourth'], label='Class 1', c='red')
    plt.scatter(dataset[classes=='class-2']['third'], dataset[classes=='class-2']['fourth'], label='Class 2', c='blue')
    plt.scatter(dataset[classes=='class-3']['third'], dataset[classes=='class-3']['fourth'], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Third')
    plt.ylabel('Fourth')
    # display
    #PCA plot
    plt.subplot(4, 3, 7 )
    min_max=MinMaxScaler()
    normalised_data=min_max.fit_transform(dataset[['first', 'second','third', 'fourth']])
    #(dataset - dataset.min())/(dataset.max() - dataset.min())
    pca = sklearnPCA(n_components=2) #2-dimensional PCA
    reduced_data = pd.DataFrame(pca.fit_transform(normalised_data))
    plt.scatter(reduced_data[classes=='class-1'][0], reduced_data[classes=='class-1'][1], label='Class 1', c='red')
    plt.scatter(reduced_data[classes=='class-2'][0], reduced_data[classes=='class-2'][1], label='Class 2', c='blue')
    plt.scatter(reduced_data[classes=='class-3'][0], reduced_data[classes=='class-3'][1], label='Class 3', c='lightgreen')
    plt.legend()
    plt.xlabel('Reduced 1')
    plt.ylabel('Reduced 2')
    # display
    plt.show()    
    plt.tight_layout()
     
     
 
if __name__ == "__main__":
    main()